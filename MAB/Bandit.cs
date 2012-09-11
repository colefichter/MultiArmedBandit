using System;
using System.Collections.Generic;
using System.Linq;

namespace MAB
{
    public sealed class Bandit<T1>
    {
        protected bool _collectDiagnostics = false;
        protected IBanditRepo<T1> _repo = null;
        protected BanditDiagnostics _diagnostics = null;

        /// <summary>
        /// The total number of trails played for all alternatives.
        /// </summary>
        public int Plays
        {
            get
            {
                //TODO: should we optimize this by creating a separate counter and storing it in this class?
                return _repo.Alternatives.Sum(x => x.Trials);
            }
        }

        public BanditDiagnostics Diagnostics
        {
            get
            {
                return this._diagnostics;
            }
        }

        public Bandit(IBanditRepo<T1> repository)
        {
            Init(repository, false);
        }

        public Bandit(IBanditRepo<T1> repository, bool collectDiagnostics)
        {
            Init(repository, collectDiagnostics);
        }

        protected void Init(IBanditRepo<T1> repository, bool collectDiagnostics)
        {
            if (repository == null)
            {
                throw new ArgumentException(@"The repository cannot be null!");
            }

            this._repo = repository;
            this._collectDiagnostics = collectDiagnostics;
            if (collectDiagnostics)
            {
                this._diagnostics = new BanditDiagnostics();
            }
        }

        /// <summary>
        /// Returns a chosen alternative for use. Currently based on the UCB1 algorithm.
        /// </summary>
        /// <returns></returns>
        public IAlternative Play()
        {
            IAlternative[] alternatives = _repo.Alternatives;

            if (alternatives == null || alternatives.Length == 0)
            {
                throw new ArgumentException(@"No alternatives were supplied by the repository!");
            }

            IAlternative selected = this.ComputeSelection(alternatives);
            selected.Play();

            return selected;
        }

        protected IAlternative ComputeSelection(IAlternative[] alternatives)
        {
            IAlternative selected = null;

            //Start off by playing each machine once. That is, start with a very short pure exploration phase.
            foreach (IAlternative a in alternatives)
            {
                if (a.Trials == 0)
                {
                    selected = a;
                }
            }

            if (selected == null)
            {
                //We know that each machine has been played at least once.
                double logPlays = Math.Log(this.Plays);

                double[] machineMeanUpperBounds = alternatives.Select<IAlternative, double>(x => x.Mean + Math.Sqrt(2 * logPlays / x.Trials)).ToArray();

                int indexOfMax = (
                    from x in machineMeanUpperBounds
                    orderby x
                    select machineMeanUpperBounds.ToList().IndexOf(x)
                ).Last();

                selected = alternatives[indexOfMax];

                if (this._collectDiagnostics)
                {
                    int indexOfMin = (
                       from x in machineMeanUpperBounds
                       orderby x
                       select machineMeanUpperBounds.ToList().IndexOf(x)
                    ).First();

                    this._diagnostics.LastBest = alternatives[indexOfMax];
                    this._diagnostics.LastWorst = alternatives[indexOfMin];

                    this._diagnostics.LastBestMean = (float)machineMeanUpperBounds[indexOfMax];
                    this._diagnostics.LastWorstMean = (float)machineMeanUpperBounds[indexOfMin];
                }
            }

            return selected;
        }
    }
}
