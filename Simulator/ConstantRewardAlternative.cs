using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MAB;

namespace Simulator
{
    public class ConstantRewardAlternative : AbstractAlternative
    {
        private float _mean = 0.5f;

        public override float Mean
        {
            get
            {
                return this._mean;
            }
        }

        public string Name
        {
            get
            {
                return _mean == 0.5f ? @"B" : @"W";
            }
        }

        public ConstantRewardAlternative()
        {
        }

        public ConstantRewardAlternative(float mean)
        {
            this._mean = mean;
        }
    }
}
