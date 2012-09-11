using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAB
{
    public abstract class AbstractAlternative : IAlternative
    {
        public virtual int Trials { get; private set; }

        public virtual double Reward { get; private set; }

        public virtual float Mean
        {
            get
            {
                if (Trials == 0)
                {
                    return 0.0f;
                }

                return (float)Reward / Trials;
            }
        }

        public virtual void Score()
        {
            this.Reward += 1;
        }

        public virtual void Play()
        {
            this.Trials += 1;
        }
    }
}
