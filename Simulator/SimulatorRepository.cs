using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAB;

namespace Simulator
{
    public class SimulatorRepository : IBanditRepo<ConstantRewardAlternative>
    {
        List<IAlternative> _alternatives = new List<IAlternative>();

        #region IBanditRepo<ConstantRewardAlternative> Members

        public IAlternative[] Alternatives
        {
            get { return this._alternatives.ToArray(); }
        }

        #endregion

        public int AddAlternative(IAlternative alternative)
        {
            this._alternatives.Add(alternative);
            return this._alternatives.Count;
        }
    }
}
