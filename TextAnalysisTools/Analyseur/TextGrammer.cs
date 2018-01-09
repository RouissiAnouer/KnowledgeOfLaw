using System.Collections.Generic;
using System.Text.RegularExpressions;
using TextAnalysisTools;

namespace TextAnalysisTools.Analyseur
{
    public class TextGrammer : IGrammer
    {
        public TextGrammer()
        {
            
            Rules = new List<LexicalRule>()
            {

                new LexicalRule {Type=TokenType.Titre,RegExpression=new Regex("^(\\s)*[T|t]itre(\\s)+[0-9]+|^(\\s)*[T|t]itre(\\s)+premier|^(\\s)*[T|t]itre(\\s)+(I|V|X)+") },

                new LexicalRule {Type=TokenType.Article,RegExpression=new Regex("^(\\s)*[A|a]rticle(\\s)+[0-9]+|^(\\s)*[A|a]rticle(\\s)+premier|^(\\s)*[A|a]rticle(\\s)+(I|V|X)+")},

                new LexicalRule {Type = TokenType.Chapitre, RegExpression =new Regex("^(\\s)*[C|c]hapitre(\\s)+[0-9]+|^(\\s)*[C|c]hapitre(\\s)+(I|V|X)+") },

                new LexicalRule {Type=TokenType.Section,RegExpression=new Regex("^(\\s)*[S|s]ection(\\s)+[0-9]+|^(\\s)*[S|s]ection(\\s)+(I|V|X)+") },

                new LexicalRule {Type=TokenType.Alena,RegExpression=new Regex(("^(\\s)*- (\\s)*")+("([A-Za-z0-9]+ )*(.*|;*|,*|!*|:*|'*|°*|<*|>*|_*|-*)*[A-Za-z0-9]*")) },

                new LexicalRule {Type=TokenType.Alena,RegExpression=new Regex(("^(\\s)*[1-9]+(\\s*)(bis|.|-) ")+("([A-Za-z0-9]+ )*(.*|;*|,*|!*|:*|'*|°*|<*|>*|_*|-*)*[A-Za-z0-9]*")) },

                new LexicalRule {Type=TokenType.Paragraph,RegExpression=new Regex(("^(\\s)*[A-Za-z0-9][A-Za-z0-9]*(.*|;*|,*|!*|:*|'*|°*|<*|>*|_*|-*)*[A-Za-z0-9]*\n")) },
                


              
            };

        }

        public string Name
        {
            get { return "Texte"; }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
