
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lexer.Grammers
{
    public class TextGrammer : IGrammer
    {
        public TextGrammer()
        {
            Rules = new List<LexicalRule>()
            {
                new LexicalRule { Type = TokenType.Chapitre, RegExpression = new Regex("Chapitre [0-9]*") }, // Comment
                new LexicalRule { Type = TokenType.WhiteSpace, RegExpression = new Regex("^\\s") }, // Whitespace
                new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^(and|or|not|is)\\b") }, // Word Operator
                new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^[\\+\\-\\*/%&|\\^~<>!]") }, // Single Char Operator
                new LexicalRule { Type = TokenType.Operator, RegExpression = new Regex("^((==)|(!=)|(<=)|(>=)|(<>)|(<<)|(>>)|(//)|(\\*\\*))") }, // Double Char Operator
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^[\\(\\)\\[\\]\\{\\}@,:`=;\\.]") }, // Single Delimiter
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^((\\+=)|(\\-=)|(\\*=)|(%=)|(/=)|(&=)|(\\|=)|(\\^=))") }, // Double Char Operator
                new LexicalRule { Type = TokenType.Delimiter, RegExpression = new Regex("^((//=)|(>>=)|(<<=)|(\\*\\*=))") }, // Triple Delimiter
                new LexicalRule {Type=TokenType.Article,RegExpression=new Regex("[A|a]rticle [0-9]*") },
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
                new LexicalRule { Type = TokenType.Identifier, RegExpression = new Regex("^[_A-Za-z][_A-Za-z0-9]*") }, // Identifier
                new LexicalRule { Type = TokenType.String, RegExpression = new Regex("^((@'(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(@\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase) }, // String Marker
                
                new LexicalRule { Type = TokenType.Unknown, RegExpression = new Regex("^.") }, // Any
            };

        }

        public string Name
        {
            get { return "Texte"; }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
