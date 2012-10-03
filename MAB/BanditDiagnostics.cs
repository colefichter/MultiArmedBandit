using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAB
{
    public sealed class BanditDiagnostics
    {
        public float LastBestMean { get; set; }
        public float LastWorstMean { get; set; }

        public float LastBestUpperBound { get; set; }
        public float LastWorstUpperBound { get; set; }

        public IAlternative LastBest { get; set; }
        public IAlternative LastWorst { get; set; }
    }
}
