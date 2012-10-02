using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MAB;

namespace WidgetWorld.Models
{
    public class PurchaseButton : IAlternative
    {
        public string Name { get; private set; }

        public PurchaseButton(string color, string buttonName)
        {
            this.Color = color;
            this.Name = buttonName;
        }

        #region IAlternative Members

        public int Trials { get; private set; }

        public double Reward { get; private set; }

        public float Mean
        {
            get
            {
                if (Trials == 0)
                {
                    return 0f;
                }
                else
                {
                    return (float)Math.Round((float)Reward / (float)Trials, 3);
                }
            }
        }

        public void Score()
        {
            this.Score(1.0);
        }

        public void Score(double increment)
        {
            this.Reward += increment;
        }

        public void Play()
        {
            this.Trials += 1;
        }

        #endregion

        public string Color { get; private set; }
    }
}