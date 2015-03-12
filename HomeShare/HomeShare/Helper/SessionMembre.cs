using HomeShareMVC.Areas.Boutique.Models;
using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Helper
{
    public static class SessionMembre
    {
        public static string Login
        {
            get
            {
                if (HttpContext.Current.Session["Login"] != null) return HttpContext.Current.Session["Login"].ToString();
                else return null;
            }

            set { HttpContext.Current.Session["Login"] = value; }
        }

        public static Transaction Transaction
        {
            get
            {


                if (HttpContext.Current.Session["Transaction"] == null)
                {
                    HttpContext.Current.Session["Transaction"] = new Transaction();


                }
                return (Transaction)HttpContext.Current.Session["Transaction"];

            }


            set

            { HttpContext.Current.Session["Transaction"] = value; }

        }



    }
}