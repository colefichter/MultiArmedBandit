using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;

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
        }
    }
}