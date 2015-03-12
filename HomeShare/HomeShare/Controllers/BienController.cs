using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShareMVC.Models;
using HomeShareDAL;

namespace HomeShareMVC.Controllers
{
    public class BienController : Controller
    {
        //
        // GET: /Bien/
        public ActionResult Details(int id)
        {
            DetailsModel D = new DetailsModel()
            {
                BienCourant = BienEchange.ChargerUnBien(id),
                ListeValeursOptions = OptionsBien.ChargerValeursOptionsBien(id),
                Membre = Membre.ChargerMembreViaBien(id),
                ListeAvis = AvisMembreBien.ChargerAvisBien(id),
            };
            return View(D);
        }
            
	}
}