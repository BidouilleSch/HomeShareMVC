using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class Membre : IClassDB<Membre>
    {
        #region Fields
        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _email;
        private int _pays;
        private string _telephone;
        private string _login;
        private string _password;
        #endregion

        #region Properties

        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public int Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion

        #region IClassDB implement

        // Sauvegarder un membre

        public bool Sauvegarder()
        {
            string Query = "";

            if (this.IdMembre == 0)
                Query = "Insert into Membre (Nom,Prenom,Email,Pays,Telephone,Password,Login) values (@Nom,@Prenom,@Email,@Pays,@Telephone,@Password,@Login)";
            else
                Query = "update Membre set Nom=@Nom,Prenom=@Prenom,Email=@Email,Pays=@Pays,Telephone=@Telephone,Password=@Password,Login=@Login where idMembre=@idMembre";

            Dictionary<string, object> ValueToSave = new Dictionary<string, object>();
            ValueToSave["idMembre"] = this.IdMembre;
            ValueToSave["Nom"] = this.Nom;
            ValueToSave["Prenom"] = this.Prenom;
            ValueToSave["Email"] = this.Email;
            ValueToSave["Pays"] = this.Pays;
            ValueToSave["Telephone"] = this.Telephone;
            ValueToSave["Password"] = this.Password;
            ValueToSave["Login"] = this.Login;
            if (GestionConnexion.Instance.saveData(Query, GenerateKey.DB, ValueToSave))
            {
                if (this.IdMembre == 0) GestionConnexion.Instance.getLastGenerateId();
                return true;
            }
            else
                return false;
        }

        // Supprimer un membre

        public bool Supprimer()
        {
            string Query = "Delete from Membre where idMembre=@idMembre";
            Dictionary<string, object> ValueToSave = new Dictionary<string, object>();
            ValueToSave["idMembre"] = this.IdMembre;
            return GestionConnexion.Instance.saveData(Query, GenerateKey.APP, ValueToSave);
        }
        #endregion

        #region Functions

        // Charger tous les membres

        public static List<Membre> ChargerTousLesMembres()
        {
            List<Membre> listeMembre = new List<Membre>();
            string Query = "Select * from Membre order by Nom";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            foreach (Dictionary<string, object> item in Datas)
            {
                Membre m = new Membre();
                m.associe(item);
                listeMembre.Add(m);
            }

            return listeMembre;
        }

        // Charger un membre via son password

        public static Membre ChargerMembreViaMotDePasse(string login, string password)
        {
            List<Membre> listeMembre = new List<Membre>();
            string Query = "Select * from Membre where Login='" + login + "'and Password='" + password + "'";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            if (Datas.Count() > 0)
            {
                Membre m = new Membre();
                m.associe(Datas[0]);
                return m;
            }
            return null;
        }

        // Charger un membre via son id

        public static Membre ChargerUnMembreViaId(int id)
        {
            string Query = "Select * from Membre where idMembre=" + id;
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            if (Datas.Count < 1) return null;

            Membre m = new Membre();
            m.associe(Datas[0]);
            return m;
        }

        // Charger le membre lié au bien
        // mb = identifiant du bien

        public static Membre ChargerMembreViaBien(int mb)
        {
            string Query = "Select Membre * from BienEchange inner join Membre on Membre.idMembre=BienEchange.IdMembre where BienEchange.idMembre=" + mb;
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            if (Datas.Count < 1) return null;

            Membre m = new Membre();
            m.associe(Datas[0]);
            return m;
        }

        public void associe(Dictionary<string, object> Datas)
        {
            this.IdMembre = int.Parse(Datas["idMembre"].ToString());
            this.Nom = Datas["Nom"].ToString();
            this.Prenom = Datas["Prenom"].ToString();
            this.Email = Datas["Email"].ToString();
            this.Pays = int.Parse(Datas["Pays"].ToString());
            this.Telephone = Datas["Telephone"].ToString();
            this.Login = Datas["Login"].ToString();
            this.Password = Datas["Password"].ToString();
        }
        #endregion
    }
}
