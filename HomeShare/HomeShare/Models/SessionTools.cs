using HomeShareMVC.Areas.Boutique.Models;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Models
{
    public static class SessionTools
    {
        public static Panier Panier
        {
            get
            {
                if (HttpContext.
                    Current.Session["Panier"] == null)
                {
                    HttpContext.
                        Current.Session["Panier"] = new Panier();
                }

                return (Panier)HttpContext.
                    Current.Session["Panier"];
            }
            set
            {
                HttpContext.
                    Current.Session["Panier"] = value;
            }
        }

        public static bool isLogged
        {
            get
            {
                if (HttpContext.
                   Current.Session["isLogged"] == null)
                {
                    HttpContext.
                        Current.Session["isLogged"] = false;
                }

                return (bool)HttpContext.
                    Current.Session["isLogged"];
            }
            set
            {
                HttpContext.
                    Current.Session["isLogged"] = value;
            }
        }

    }
}