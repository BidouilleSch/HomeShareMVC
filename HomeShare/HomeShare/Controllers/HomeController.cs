
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShareMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int Page = 1)
        {

            Double d = (double)(HomeShareDAL.BienEchange.ChargerLesDerniersBiens().Count());
            ViewBag.tot = Math.Ceiling(d / 3);

            return View(HomeShareDAL.BienEchange.ChargerPagination(Page));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}