﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

using MAB;
using WidgetWorld.Models;

namespace WidgetWorld.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Widget World!";

            //Ask our Bandit to select a button variant to display:
            Bandit<PurchaseButton> bandit = (Bandit<PurchaseButton>)HttpContext.Cache.Get(@"bandit");
            PurchaseButton selectedButton = bandit.Play();

            ViewBag.ButtonColor = selectedButton.Color;
            ViewBag.ButtonName = selectedButton.Name;

            return View();
        }

        public ActionResult Status()
        {
            ViewBag.Alternatives = (new WidgetRepo()).Alternatives;

            Bandit<PurchaseButton> bandit = (Bandit<PurchaseButton>)HttpContext.Cache.Get(@"bandit");
            ViewBag.BanditDiagnostics = bandit.Diagnostics;

            return View();
        }

        public ActionResult Buy(string buttonName)
        {
            ViewBag.ButtonName = buttonName;

            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Buy(string buttonName, int amount)
        {
            foreach (PurchaseButton button in (new WidgetRepo()).Alternatives)
            {
                if (button.Name == buttonName)
                {
                    button.Score((double) amount);
                    break;
                }
            }

            return RedirectToAction(@"Index");
        }

        public ActionResult How()
        {
            return View();
        }
    }
}
