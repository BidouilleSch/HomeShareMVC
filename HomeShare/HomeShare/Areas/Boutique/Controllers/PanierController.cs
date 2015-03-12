using HomeShareDAL;
using HomeShareMVC.Models;
using HomeShareMVC.Areas.Boutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeShareMVC.Helper;

namespace HomeExchange.Areas.Boutique.Controllers
{
    public class TransactionController : Controller
    {
        //
        // GET: /Boutique/Transaction/
        public ActionResult Index()
        {
            return View("Transaction", SessionMembre.Transaction);
        }

        /*
         * 
        [HttpGet] // Je voulais faire un panier afin de pouvoir ajouter les frais de dossier et les frais d'assurance grâce à ton commentaire 
         * je n'ai pas perdu plus de temps*/
        
        public ActionResult AnnulerTransaction(int id)
        {
            SessionMembre.Transaction.Lignes.Remove(SessionMembre.Transaction.Lignes.Where(li => li.BienChoisi.IdBien == id).FirstOrDefault());
            return View("Transaction", SessionMembre.Transaction);
        }



    }
}