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
}
