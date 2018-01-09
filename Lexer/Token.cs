
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    /// <summary>
    /// Meaning full characters span
    /// </summary>
    public class Token
    {
        public Token(int startIndex, int length, TokenType type)
        {
            StartIndex = startIndex;
            Length = length;
            Type = type;
        }

        public TokenType Type { get; private set; }

        public int StartIndex { get; private set; }

        public int Length { get; private set; }
    }
}
