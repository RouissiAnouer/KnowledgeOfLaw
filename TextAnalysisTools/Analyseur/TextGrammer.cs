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
                


                //new LexicalRule {Type=TokenType.Paragraph,RegExpression=new Regex("([aA-zZ]+'*[aA-zZ]* )+(\\s)*|([aA-zZ]+ )+[aA-zZ]*") },

                

                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                //new LexicalRule {Type = TokenType.WhiteSpace, RegExpression = new Regex("^\\s") }, // Whitespace
                /*new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^(and|or|not|is)\\b") }, // Word Operator
                //new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^[\\+\\-\\/%&|\\^~<>!]") }, // Single Char Operator
                new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^((==)|(!=)|(<=)|(>=)|(<>)|(<<)|(>>)|(//)|(\\*\\*))") }, // Double Char Operator
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^[\\(\\)\\[\\]\\{\\}@,:`=;\\.]") }, // Single Delimiter
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^((\\+=)|(\\-=)|(\\*=)|(%=)|(/=)|(&=)|(\\|=)|(\\^=))") }, // Double Char Operator
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^((//=)|(>>=)|(<<=)|(\\*\\*=))") }, // Triple Delimiter
                new LexicalRule { Type = TokenType.Keyword, RegExpression = LexicalRule.WordRegex("as", "assert", "break", "class", "continue", "def", "del", "elif", "else", "except", "finally", "for", "from", "global", "if", "import", "lambda", "pass", "raise", "return", "try", "while", "with", "yield", "in", "print") }, // Keywords
                new LexicalRule {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                                      "ArithmeticError", "AssertionError", "AttributeError", "BaseException",
                                      "BufferError", "BytesWarning", "DeprecationWarning", "EOFError", "Ellipsis",
                                      "EnvironmentError", "Exception", "False", "FloatingPointError", "FutureWarning",
                                      "GeneratorExit", "IOError", "ImportError", "ImportWarning", "IndentationError",
                                      "IndexError", "KeyError", "KeyboardInterrupt", "LookupError", "MemoryError",
                                      "NameError", "None", "NotImplemented", "NotImplementedError", "OSError",
                                      "OverflowError", "PendingDeprecationWarning", "ReferenceError", "RuntimeError",
                                      "RuntimeWarning", "StandardError", "StopIteration", "SyntaxError",
                                      "SyntaxWarning", "SystemError", "SystemExit", "TabError", "True", "TypeError",
                                      "UnboundLocalError", "UnicodeDecodeError", "UnicodeEncodeError", "UnicodeError",
                                      "UnicodeTranslateError", "UnicodeWarning", "UserWarning", "ValueError", "Warning",
                                      "WindowsError", "ZeroDivisionError", "_", "__debug__", "__doc__", "__import__",
                                      "__name__", "__package__", "abs", "all", "any", "apply", "basestring", "bin",
                                      "bool", "buffer", "bytearray", "bytes", "callable", "chr", "classmethod",
                                      "cmp", "coerce", "complex", "copyright", "credits", "delattr",
                                      "dict", "divmod", "enumerate", "filter", "float",
                                      "format", "frozenset", "getattr", "hasattr",
                                      "hash", "hex", "id", "int", "intern", "isinstance", "issubclass",
                                      "iter", "len", "license", "list", "long", "map", "max", "memoryview",
                                      "min", "next", "object", "oct", "ord", "pow", "print", "property",
                                      "range", "raw_input", "reduce", "repr", "reversed",
                                      "round", "set", "setattr", "slice", "sorted", "staticmethod", "str", "sum",
                                      "super", "tuple", "type", "unichr", "unicode", "xrange", "zip") },
                //new LexicalRule { Type = TokenType.Identifier, RegExpression = new Regex("^[_A-Za-z][_A-Za-z0-9]*") }, // Identifier
                new LexicalRule { Type = TokenType.String, RegExpression = new Regex("^((@'(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(@\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase) }, // String Marker
                
                //new LexicalRule { Type = TokenType.Unknown, RegExpression = new Regex("^.") }, // Any*/
            };

        }

        public string Name
        {
            get { return "Texte"; }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}