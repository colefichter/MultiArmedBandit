using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using MAB;
using WidgetWorld.Models;

namespace WidgetWorld
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitBanditRepo();
        }

        private void InitBanditRepo()
        {
            //Create the alternatives used in the bandit
            var blueButton = new Models.PurchaseButton(@"#4983FF", @"Blue button");
            var redButton = new Models.PurchaseButton(@"#974037", @"Red button");

            var buttons = new List<Models.PurchaseButton>();
            buttons.Add(blueButton);
            buttons.Add(redButton);

            //Very naive repo implementation... just use the cache.
            HttpContext.Current.Cache.Remove(@"alternatives");
            HttpContext.Current.Cache.Add(@"alternatives", buttons, null, Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), CacheItemPriority.Normal, null);

            //If you want to track diagnostic info across requests (like for the status page), keep this around, like in a singleton...
            Bandit<PurchaseButton> bandit = new Bandit<PurchaseButton>(new WidgetRepo(), true);
            HttpContext.Current.Cache.Add(@"bandit", bandit, null, Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0), CacheItemPriority.Normal, null);
        }
    }
}