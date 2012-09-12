using System;

namespace MAB
{
    public interface IAlternative
    {
        /// <summary>
        /// The number of trials in which this alternative was selected for play.
        /// </summary>
        int Trials { get; }

        /// <summary>
        /// The sum of the rewards earned by this alternative.
        /// </summary>
        double Reward { get; }

        /// <summary>
        /// The mean of the reward among all trials.
        /// </summary>
        float Mean { get; }

        /// <summary>
        /// Increment by 1 the reward accumulated for this alternative. This method assumes a Bernoulli distribution of reward.
        /// </summary>
        void Score();

        /// <summary>
        /// Increment by <paramref name="increment"/> the reward accumulated for this alternative. This method does not assume any particular distribution of reward.
        /// </summary>
        /// <param name="increment">The amount by which to increase the accumulated reward.</param>
        void Score(double increment);

        /// <summary>
        /// Increment the number of trials run for this alternative.
        /// </summary>
        void Play();
    }
}
