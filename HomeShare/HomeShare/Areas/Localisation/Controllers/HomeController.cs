using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShareDAL;

namespace HomeShareMVC.Areas.Localisation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Localisation/Home/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string txtidbien)
        {

            BienEchange b = BienEchange.getInfo(txtidbien);
            if (b != null)
            {

                return View("localisation", b);

            }

            else
            {
                return View("nullepart", b);
            }

        }
    }
}


