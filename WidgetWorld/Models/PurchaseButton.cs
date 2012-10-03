using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MAB;

namespace WidgetWorld.Models
{
    public class PurchaseButton : AbstractAlternative
    {
        public string Name { get; private set; }
        public string Color { get; private set; }

        public PurchaseButton(string color, string buttonName)
        {
            this.Color = color;
            this.Name = buttonName;
        }
        
        public override float Mean
        {
            get
            {
                //if (Trials == 0)
                //{
                //    return 0f;
                //}
                //else
                //{
                //    return (float)Math.Round((float)Reward / (float)Trials, 3);
                //}

                return (float)Math.Round(base.Mean, 3);
            }
        }

        public override void Score(double increment)
        {
            this.Reward += increment;
        }
    }
}