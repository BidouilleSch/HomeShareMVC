using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeShareDAL;

namespace HomeShareMVC.Models
{
    public class DetailsModel : HomeModel
    {
        public BienEchange BienCourant
        {
            get;
            set;
        }

        public Membre Membre
        {
            get;
            set;
        }

        public Pays PaysBien
        {
            get;
            set;
        }

        public Pays PaysMembre
        {
            get;
            set;
        }

        public List<AvisMembreBien> ListeAvis
        {
            get;
            set;
        }

        public List<OptionsBien> ListeValeursOptions
        {
            get;
            set;
        }

        public List<Options> listeLibelleOptions
        {
            get;
            set;
        }
    }
}


