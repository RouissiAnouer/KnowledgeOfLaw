
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public interface IGrammer
    {
        string Name { get; }

        List<LexicalRule> Rules { get; }
    }
}
