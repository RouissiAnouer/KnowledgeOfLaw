
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lexer
{
    public class Tokenizer
    {
        public Tokenizer(IGrammer grammer)
        {
            Grammer = grammer;
        }

        public IGrammer Grammer { get; private set; }

        public IEnumerable<Token> Tokenize(string script)
        {
            if (string.IsNullOrEmpty(script))
                throw new ArgumentNullException("script");

            int i = 0;
            int length = script.Length;

            Match match;
            var builder = new StringBuilder(script);

            string str = script;

            while (i < length)
            {
                foreach (var rule in Grammer.Rules)
                {
                    match = rule.RegExpression.Match(str);
                    
                    if (match.Success)
                    {
                        if (match.Length == 0)
                        {
                            throw new Exception(string.Format("Regex matche length is zero. This can lead to infinite loop. Please modify your regex {0} for {1} so that it can't matche character of zero length", rule.RegExpression, rule.Type));
                        }

                        yield return new Token(i, match.Length, rule.Type);
                        i += match.Length;

                        builder.Remove(0, match.Length);
                        break;
                    }
                }

                str = builder.ToString();
            }
        }
    }
}
