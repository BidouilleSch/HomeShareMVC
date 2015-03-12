using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Options
    {
        #region Fields


        private int _idOption;
        private string _libelle;
        private List<BienEchange> _biens;
        private List<Options> _listeOptions = null;

        #endregion

        #region Properties

        public List<BienEchange> Biens
        {
            get { return _biens = _biens ?? ChargerLesBiens(); }

        }

        public int IdOption
        {
            get { return _idOption; }
            set { _idOption = value; }
        }


        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }


        #endregion

        #region Functions

        private List<BienEchange> ChargerLesBiens()
        {
            string query = @"select b.* from BienEchange b
                            inner join OptionsBien ob 
                            on b.idBien = ob.idBien
                            where ob.idOption =" + this.IdOption;
            List<BienEchange> retour = new List<BienEchange>();
            List<Dictionary<string, object>> MesBiens = GestionConnexion.Instance.getData(query);
            foreach (Dictionary<string, object> item in MesBiens)
            {
                BienEchange bien = new BienEchange()
                {
                    IdBien = (int)item["idBien"],
                    Titre = item["Titre"].ToString(),
                    DescCourte = item["DescCourte"].ToString(),
                    DescLong = item["DescLong"].ToString(),
                    NombrePerson = (int)item["NombrePerson"],
                    Pays = (int)item["Pays"],
                    Rue = item["Rue"].ToString(),
                    Numero = item["Numero"].ToString(),
                    CodePostal = (string)item["CodePostal"],
               
                    Photo = item["Photo"].ToString(),
                    AssuranceObligatoire = (bool)item["AssuranceObligatoire"],
                    IsEnabled = (bool)item["isEnabled"],
                    Latitude = item["Latitude"].ToString(),
                    Longitude = item["Longitude"].ToString(),
                    DateCreation = (DateTime)item["DateCreation"],
                    IdMembre = (int)item["idMembre"],
                    
                };


                retour.Add(bien);
            }

            return retour;
        }




        #endregion

        #region Static
        /// <summary>
        /// Permet de charger une option de la DB via sa clé primaire
        /// </summary>
        /// <param name="idop">Identifiant unique de l' option</param>
        /// <returns>l'option correspondante</returns>
        public static Options ChargerUneOption(int idop)
        {
            List<Dictionary<string, object>> UneOption = GestionConnexion.Instance.getData("select * from Options where idOption=" + idop);
            Options opt = Associe(UneOption[0]);
            return opt;
        }
        /// <summary>
        /// Permet de charger la liste complète de toutes les options en DB
        /// </summary>
        /// <returns>la liste complète de toutes les options en DB</returns>
        public static List<Options> ChargerToutesLesOptions()
        {
            List<Options> retour = new List<Options>();
            List<Dictionary<string, object>> LesOptions = GestionConnexion.Instance.getData("select * from Options");
            foreach (Dictionary<string, object> item in LesOptions)
            {
                retour.Add(Associe(item));
            }
            return retour;

        }
        /// <summary>
        /// Permet d'associer les infos récupérées de la DB avec les propriétés d'une option
        /// </summary>
        /// <param name="UneItLang">Un dictionnaire contenant les données BD</param>
        /// <returns>L'option remplie</returns>
        private static Options Associe(Dictionary<string, object> UneOption)
        {
            Options opt = new Options();
            opt.IdOption = (int)UneOption["idOption"];
            opt.Libelle = UneOption["Libelle"].ToString();
            return opt;
        }
        #endregion
    }
}
