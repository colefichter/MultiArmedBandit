using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using MAB;

namespace WidgetWorld.Models
{
    public class WidgetRepo : IBanditRepo<PurchaseButton>
    {
        #region IBanditRepo<PurchaseButton> Members

        public IAlternative[] Alternatives
        {
            get 
            {
                //Very naive repo implementation... just use the cache.
                //The cache variable is created in Global.asax when the application starts.
                List<PurchaseButton> buttons = (List<PurchaseButton>) HttpContext.Current.Cache.Get(@"alternatives");
                return (IAlternative[])buttons.ToArray();
            }
        }

        #endregion
    }
}
