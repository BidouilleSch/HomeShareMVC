using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Helper
{
    public static class Utils
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

        public static Membre User
        {
            get { return (Membre)HttpContext.Current.Session["User"]; }
            set { HttpContext.Current.Session["User"] = value; }
        }
        
    }
}