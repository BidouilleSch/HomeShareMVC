using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Pays
    {
        #region Fields
        private int _idPays;
        private string _libelle;
        #endregion

        #region Properties
        public int IdPays
        {
            get { return _idPays; }
            set { _idPays = value; }
        }

        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = value; }
        }
#endregion 
        #region Functions
       

        public void associe(Dictionary<string, object> Datas)
        {
            this.IdPays = int.Parse(Datas["idPays"].ToString());
            this.Libelle = Datas["Libelle"].ToString();
          
        }


        public static List<Pays> ChargerTousLesPays()
        {
            List<Pays> listePays = new List<Pays>();
            string Query = "Select * from Pays";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);

            foreach (Dictionary<string, object> item in Datas)
            {
                Pays p = new Pays();
                p.associe(item);
                listePays.Add(p);
            }

            return listePays;
        }

        #endregion

    }
}
