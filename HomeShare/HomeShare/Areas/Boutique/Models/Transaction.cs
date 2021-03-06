﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareMVC.Areas.Boutique.Models
{
    public class Transaction
    {

        private List<Ligne> _lignes;

        public List<Ligne> Lignes
        {
            get { return _lignes = _lignes ?? new List<Ligne>(); }
            set { _lignes = value; }
        }

        public Double Total
        {
            get { return FnTotal(); }
        }

        private Double FnTotal()
        {
            return Lignes.Sum(e => e.Cout);
        }

    }
}