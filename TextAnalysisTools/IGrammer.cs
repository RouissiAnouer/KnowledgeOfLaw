
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysisTools
{
    public interface IGrammer
    {
        string Name { get; }

        List<LexicalRule> Rules { get; }
    }
}
