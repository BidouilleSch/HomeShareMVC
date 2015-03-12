using HomeShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeShareMVC.Areas.Boutique.Models
{
    public class Ligne
    {

        private BienEchange _bienChoisi;
        private DateTime _dateDebEchange;
        private DateTime _dateFinEchange;
        private bool _assurance = true;
        private int _fraisDossier;
        private int _cout;
        private int _quantité;

        public BienEchange BienChoisi
        {
            get;
            set;
        }

        public DateTime DateDebEchange
        {
            get;
            set;
        }

        public DateTime DateFinEchange
        {
            get;
            set;
        }

        public bool Assurance
        {
            get
            {
                if (Assurance == true)
                {

                    return Assurance;

                }
                else
                {
                    return false;
                }
            }
        }

        public int FraisDossier
        {
            get { return 5; }
        }

        public int Cout
        {
            get { return 5; }
        }


        public int PrixAssurance()
        {
            System.DateTime dateDepart = Convert.ToDateTime(DateDebEchange);
            System.DateTime dateRetour = Convert.ToDateTime(DateFinEchange);
            System.TimeSpan nbJour = dateRetour.Subtract(dateDepart);
            int prixJour = 10 ;
            int PrixAssurance = nbJour.Days * prixJour;
            return PrixAssurance;
        }
       
    }
}

       