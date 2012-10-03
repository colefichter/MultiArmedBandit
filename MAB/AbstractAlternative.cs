using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAB
{
    public abstract class AbstractAlternative : IAlternative
    {
        /// <summary>
        /// The number of trials in which this alternative was selected for play.
        /// </summary>
        public virtual int Trials { get; protected set; }

        /// <summary>
        /// The sum of the rewards earned by this alternative.
        /// </summary>
        public virtual double Reward { get; protected set; }

        /// <summary>
        /// The mean of the reward among all trials.
        /// </summary>
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

        /// <summary>
        /// Increment by 1 the reward accumulated for this alternative. This method assumes a Bernoulli distribution of reward.
        /// </summary>
        public virtual void Score()
        {
            this.Score(1.0);
        }

        /// <summary>
        /// Increment by <paramref name="increment"/> the reward accumulated for this alternative. This method does not assume any particular distribution of reward.
        /// </summary>
        /// <param name="increment">The amount by which to increase the accumulated reward.</param>
        public virtual void Score(double increment)
        {
            throw new NotImplementedException(@"You must override this method in your concrete implementation of AbstractAlternative.");
        }

        /// <summary>
        /// Increment the number of trials run for this alternative.
        /// </summary>
        public virtual void Play()
        {
            this.Trials += 1;
        }
    }
}
