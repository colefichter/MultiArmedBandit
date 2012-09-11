using System;

namespace MAB
{
    public interface IAlternative
    {
        int Trials { get; }
        double Reward { get; }
        float Mean { get; }

        /// <summary>
        /// Increment the reward accumlated by this alternative
        /// </summary>
        void Score();

        /// <summary>
        /// Increment the number of trials run for this alternative.
        /// </summary>
        void Play();
    }
}
