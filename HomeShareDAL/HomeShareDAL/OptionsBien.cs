using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class OptionsBien
    {
        #region Fields
        private int _idOption;
        private int _idBien;
        private string _valeur;
        #endregion

        #region Properties
        public int IdOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }

        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public string Valeur
        {
            get { return _valeur; }
            set { _valeur = value; }
        }
        #endregion

        #region Function
        private List<OptionsBien> ChargerOptionsBien()
        {
            return OptionsBien.ChargerValeursOptionsBien(this.IdBien);
        }

        public static List<OptionsBien> ChargerValeursOptionsBien(int idob)
        {
            List<OptionsBien> retour = new List<OptionsBien>();

            List<Dictionary<string, object>> LesValeurs = GestionConnexion.Instance.getData("Select BienEchange.idBien, OptionsBien.idBien AS Expr1, OptionsBien.idOption AS Expr2, Options.Libelle, OptionsBien.Valeur, Options.idOption FROM BienEchange INNER JOIN OptionsBien ON BienEchange.idBien = OptionsBien.idBien INNER JOIN Options ON OptionsBien.idOption = Options.idOption where BienEchange.idBien=" + idob);

            foreach (Dictionary<string, object> item in LesValeurs)
            {
                OptionsBien ob = new OptionsBien()
                {
                    Valeur = item["Valeur"].ToString()
                };

                retour.Add(ob);
            }
            return retour;

        }
        #endregion
    }
}
