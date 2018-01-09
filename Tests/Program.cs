using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static String Normalize(String[] lines)
        {
            string toReturn = "";
            foreach (var line in lines)
            {
                toReturn += line + "\n";
            }

            return toReturn;

        }

        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Anouer\Desktop\BitLord\Sujet de stage analyse text\Exemples\code\fr\coddroitenrg.txt");


            var script = string.Join("\n", lines);

            var tokenizer = new TextAnalysisTools.Tokenizer(new TextAnalysisTools.Analyseur.TextGrammer());

            foreach (var token in tokenizer.Tokenize(script))
            {
                Console.WriteLine("{0} => {1}", token.Type, script.Substring(token.StartIndex, token.Length));
            }

            Console.ReadLine();
        }
    }
}/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAnalysisTools;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new List<string>();

            Console.WriteLine("Enter python script to tokenize below. Leave line empty to tokenize");

            string line;
            do
            {
                Console.Write("> ");
                line = Console.ReadLine();

                lines.Add(line);

            } while (!string.IsNullOrEmpty(line));

            var script = string.Join("\n", lines);

            var tokenizer = new TextAnalysisTools.Tokenizer(new TextAnalysisTools.Analyseur.TextGrammer());

            foreach (var token in tokenizer.Tokenize(script))
            {
                Console.WriteLine("{0}:{1} - {2} => {3}", token.StartIndex, token.Length, token.Type, script.Substring(token.StartIndex, token.Length));
            }

            Console.ReadLine();
        }
    }
}*/