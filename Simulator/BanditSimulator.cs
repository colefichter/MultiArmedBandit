using System;

using MAB;

namespace Simulator
{
    public class BanditSimulator
    {
        int _iterations = 5000;

        IBanditRepo<ConstantRewardAlternative> _repo = null;
        Bandit<ConstantRewardAlternative> _bandit = null;

        public BanditSimulator() { }

        public void Run()
        {
            InitBandit();

            IAlternative lastSelected = null;
            for (int i = 0; i < this._iterations; i++)
            {
                IAlternative selected = this._bandit.Play();
                if (selected != lastSelected || (i + 1) % 1000 == 0)
                {
                    WL(i + 1, selected);
                    lastSelected = selected;
                }
            }

            Console.WriteLine("Running.");
        }

        private void InitBandit()
        {
            this._repo = CreateRepo();
            this._bandit = new Bandit<ConstantRewardAlternative>(this._repo, true);
        }

        private IBanditRepo<ConstantRewardAlternative> CreateRepo()
        {
            SimulatorRepository repo = new SimulatorRepository();
            repo.AddAlternative(new ConstantRewardAlternative(0.5f)); //best
            repo.AddAlternative(new ConstantRewardAlternative(0.35f)); //worst

            return repo;
        }

        private void WL(int trial, IAlternative alternative)
        {
            if (this._bandit.Diagnostics.LastBest == null)
            {
                Console.WriteLine(
                    string.Format("{0}\t{1}",trial, ((ConstantRewardAlternative)alternative).Name)
                );
            }
            else
            {
                Console.WriteLine(
                    string.Format("{0}\t{1}\tBest {2} {3}\tWorst {4} {5}",
                        trial, ((ConstantRewardAlternative)alternative).Name,
                        ((ConstantRewardAlternative)this._bandit.Diagnostics.LastBest).Name, Math.Round(this._bandit.Diagnostics.LastBestMean, 4),
                        ((ConstantRewardAlternative)this._bandit.Diagnostics.LastWorst).Name, Math.Round(this._bandit.Diagnostics.LastWorstMean, 4))
                    );
            }
        }
    }
}
