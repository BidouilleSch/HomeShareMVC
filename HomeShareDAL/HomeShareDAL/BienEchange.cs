using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeShareDAL
{
    public class BienEchange : IClassDB<BienEchange>
    {
        #region Fields
        private int _idBien;
        private string _titre;
        private string _descCourte;
        private string _descLong;
        private int _nombrePerson;
        private int _pays;
        private string _ville;
        private string _rue;
        private string _numero;
        private string _codePostal;
        private string _photo;
        private bool _assuranceObligatoire;
        private bool _isEnabled;
        private DateTime? _disabledDate;
        private string _latitude;
        private string _longitude;
        private int _idMembre;
        private DateTime _dateCreation;
        private List<AvisMembreBien> _ListeAvis = null;
        #endregion

        #region Properties
        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public string Titre
        {
            get { return _titre; }
            set { _titre = value; }
        }

        public string DescCourte
        {
            get { return _descCourte; }
            set { _descCourte = value; }
        }

        public string DescLong
        {
            get { return _descLong; }
            set { _descLong = value; }
        }

        public int NombrePerson
        {
            get { return _nombrePerson; }
            set { _nombrePerson = value; }
        }

        public int Pays
        {
            get { return _pays; }
            set { _pays = value; }
        }

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }

        public string Rue
        {
            get { return _rue; }
            set { _rue = value; }
        }

        public string Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string CodePostal
        {
            get { return _codePostal; }
            set { _codePostal = value; }
        }

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public bool AssuranceObligatoire
        {
            get { return _assuranceObligatoire; }
            set { _assuranceObligatoire = value; }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        public DateTime? DisabledDate
        {
            get { return _disabledDate; }
            set { _disabledDate = value; }
        }

        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public string Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public DateTime DateCreation
        {
            get { return _dateCreation; }
            set { _dateCreation = value; }
        }

        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }

        public List<AvisMembreBien> ListeAvis
        {
            get { return _ListeAvis; }
            set { _ListeAvis = value; }
        }

        #endregion

        #region IClassDB implement

        // Enregistrer un bien

        public bool Sauvegarder()
        {
            string Query = "";

            if (this.IdBien == 0)
                //modifier idParticulier en idMembre, etc...
                Query = "Insert into Bien (idMembre,titre,DescCourte,DescLong,NombrePerson,Pays,Rue,Numero,CodePostal,Photo,AssuranceObligatoire,isEnabled,DisabledDate,Latitude,Longitude,DateCreation) values (@idMembre,@titre,@DescCourte,@DescLong,@NombrePerson,@Pays,@Rue,@Numero,@CodePostal,@Photo,@AssuranceObligatoire,@isEnabled,@DisabledDate,@Latitude,@Longitude,@DateCreation)";
            else
                Query = "update Bien set idMembre=@idMembre,titre=@titre,DesCourte=@DescCourte,DesLong=@DescLong,NombrePerson=@NombrePerson,Pays=@Pays,Rue=@Rue,CodePostal=@CodePostal,Photo=@Photo,AssuranceObligatoire=@AssuranceObligatoire,isEnabled=@isEnabled,DisabledDate=@DisabledDate,Latitude=@Latitude,Longitude=@Longitude,DateCreation=@DateCreation where idBien=@idBien";

            Dictionary<string, object> ValueToSave = new Dictionary<string, object>();
            ValueToSave["idMembre"] = this.IdMembre;
            ValueToSave["idBien"] = this.IdBien;
            ValueToSave["titre"] = this.Titre;
            ValueToSave["DescCourte"] = this.DescCourte;
            ValueToSave["DescLong"] = this.DescLong;
            ValueToSave["NombrePerson"] = this.NombrePerson;
            ValueToSave["Pays"] = this.Pays;
            ValueToSave["Rue"] = this.Rue;
            ValueToSave["Numero"] = this.Numero;
            ValueToSave["CodePostal"] = this.CodePostal;
            ValueToSave["Photo"] = this.Photo;
            ValueToSave["AssuranceObligatoire"] = this.AssuranceObligatoire;
            ValueToSave["isEnabled"] = this.IsEnabled;
            ValueToSave["DisabledDate"] = this.DisabledDate;
            ValueToSave["Latitude"] = this.Latitude;
            ValueToSave["Longitude"] = this.Longitude;
            ValueToSave["DateCreation"] = this.DateCreation;
            if (GestionConnexion.Instance.saveData(Query, GenerateKey.DB, ValueToSave))
            {
                if (this.IdBien == 0) this.IdBien = GestionConnexion.Instance.getLastGenerateId();
                return true;
            }
            else
                return false;
        }

        // Supprimer un bien

        public bool Supprimer()
        {
            string Query = "Delete from BienEchange where idBien=@idBien";
            Dictionary<string, object> ValueToSave = new Dictionary<string, object>();
            ValueToSave["idBien"] = this.IdBien;
            return GestionConnexion.Instance.saveData(Query, GenerateKey.APP, ValueToSave);
        }
        #endregion

        #region Functions

        public void associe(Dictionary<string, object> Datas)
        {
            this.IdMembre = int.Parse(Datas["idMembre"].ToString());
            this.IdBien = int.Parse(Datas["idBien"].ToString());
            this.Titre = Datas["titre"].ToString();
            this.DescCourte = Datas["DescCourte"].ToString();
            this.DescLong = Datas["DescLong"].ToString();
            this.NombrePerson = int.Parse(Datas["NombrePerson"].ToString());
            this.Pays = int.Parse(Datas["Pays"].ToString());
            this.Rue = Datas["Rue"].ToString();
            this.Numero = Datas["Numero"].ToString();
            this.CodePostal = Datas["CodePostal"].ToString();
            this.Photo = Datas["Photo"].ToString();
            this.AssuranceObligatoire = bool.Parse(Datas["AssuranceObligatoire"].ToString());
            this.IsEnabled = bool.Parse(Datas["isEnabled"].ToString());
            if (Datas["DisabledDate"].ToString() != "") this.DisabledDate = DateTime.Parse(Datas["DisabledDate"].ToString());
            this.Latitude = Datas["Latitude"].ToString();
            this.Longitude = Datas["Longitude"].ToString();
            this.DateCreation = DateTime.Parse(Datas["DateCreation"].ToString());
        }

        // Charger un bien via son ID

        public static BienEchange ChargerUnBien(int id)
        {
            string Query = "Select BienEchange.idBien,BienEchange.titre,BienEchange.DescCourte,MembreBienEchange.DateDebEchange,MembreBienEchange.DateFinEchange,MembreBienEchange.Assurance,MembreBienEchange.Valide,membre.idMembre ,membre.Nom,membre.Prenom,membre.Email,membre.Pays,membre.Telephone,membre.Login,membre.Password,AvisMembreBien.idAvis,AvisMembreBien.note,AvisMembreBien.message,AvisMembreBien.DateAvis, AvisMembreBien.Approuve, Options.idOption,Options.Libelle, OptionsBien.idOption ,Pays.Libelle as 'Pays' from MembreBienEchange inner join membre on MembreBienEchange.idMembre = membre.idMembre inner join BienEchange on MembreBienEchange.idBien = BienEchange.idBien left outer join AvisMembreBien on BienEchange.idBien = AvisMembreBien.idBien inner join OptionsBien on BienEchange.idBien = OptionsBien.idBien inner join Options on OptionsBien.idOption = Options.idOption inner join Pays on BienEchange.Pays = Pays.idPays where MembreBienEchange.idBien =" + id;
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            if (Datas.Count < 1) return null;

            BienEchange b = new BienEchange();
            b.associe(Datas[0]);
            return b;
        }


        // Charger tous les biens

        public static List<BienEchange> ChargerTousLesBiens()
        {
            List<BienEchange> listeBiens = new List<BienEchange>();
            string Query = "Select * from BienEchange";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);

            foreach (Dictionary<string, object> item in Datas)
            {
                BienEchange b = new BienEchange();
                b.associe(item);
                listeBiens.Add(b);
            }

            return listeBiens;
        }

        // Charger les 5 derniers biens
        public static List<BienEchange> ChargerLesDerniersBiens()
        {
            List<BienEchange> listeDerniersBiens = new List<BienEchange>();
            string Query = "SELECT TOP (5) idBien, titre, DescCourte, DescLong, NombrePerson, Pays, Ville, Rue, Numero, CodePostal, Photo, AssuranceObligatoire, isEnabled, DisabledDate, Latitude, Longitude, idMembre, DateCreation FROM dbo.BienEchange ORDER BY DateCreation DESC";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);

            foreach (Dictionary<string, object> item in Datas)
            {
                BienEchange b = new BienEchange();
                b.associe(item);
                listeDerniersBiens.Add(b);
            }

            return listeDerniersBiens;
        }

        // Charger les echanges les mieux côtés
        public static List<BienEchange> ChargerLesMeilleursEchange()
        {
            List<BienEchange> listeMeilleursEchanges = new List<BienEchange>();
            string Query = "SELECT  TOP (100) PERCENT dbo.BienEchange.idBien, dbo.BienEchange.titre, dbo.BienEchange.DescCourte, dbo.BienEchange.DescLong, dbo.BienEchange.NombrePerson, dbo.BienEchange.Pays, dbo.BienEchange.Ville, dbo.BienEchange.Rue, dbo.BienEchange.Numero, dbo.BienEchange.CodePostal, dbo.BienEchange.Photo, dbo.BienEchange.AssuranceObligatoire, dbo.BienEchange.isEnabled, dbo.BienEchange.DisabledDate, dbo.BienEchange.Latitude, dbo.BienEchange.Longitude, dbo.BienEchange.idMembre, dbo.BienEchange.DateCreation FROM dbo.AvisMembreBien INNER JOIN dbo.BienEchange ON dbo.AvisMembreBien.idBien = dbo.BienEchange.idBien WHERE (dbo.AvisMembreBien.note > 6) ORDER BY dbo.AvisMembreBien.note DESC";
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);

            foreach (Dictionary<string, object> item in Datas)
            {
                BienEchange b = new BienEchange();
                b.associe(item);
                listeMeilleursEchanges.Add(b);
            }

            return listeMeilleursEchanges;
        }

        // Charge les biens via son membre

        public static List<BienEchange> ChargerBienViaMembre(int bm)
        {
            List<BienEchange> listeBienMembre = new List<BienEchange>();
            string Query = "Select * from BienEchange where idMembre=" + bm;
            List<Dictionary<string, object>> Datas = GestionConnexion.Instance.getData(Query);
            foreach (Dictionary<string, object> item in Datas)
            {
                BienEchange b = new BienEchange();
                b.associe(item);
                listeBienMembre.Add(b);
            }
            return listeBienMembre;
        }

        // Charger les avis 

        private List<AvisMembreBien> ChargerAvis()
        {
            return AvisMembreBien.ChargerAvisBien(this.IdBien);
        }

        // Charger la pagination

        public static List<BienEchange> ChargerPagination(int page)
        {
            return BienEchange.ChargerTousLesBiens().Skip(3 * (page - 1)).Take(3).ToList();
        }
        #endregion

        #region Methode Static
        /// <summary>
        /// Permet de récupérer Bien de la DB via son identifiant
        /// </summary>
        /// <param name="identifiant">l'identifiant du bien (IDBien)</param>
        /// <param name="b">La bien a remplir</param>
        /// <returns>Une instance de bien completé par les infos de la DB</returns>
        public static BienEchange getInfo(string identifiant, BienEchange b = null)
        {
            //1 - Créér mon objet connection

            SqlConnection oConn = new SqlConnection(HomeShareDAL.Properties.Settings.Default.ConnectionString);
            //2 - Connectez-vous
            try
            {
                oConn.Open();

                //3- Construction de ma requête
                string query = @"select * from BienEchange 
                                where IDBien='" + identifiant + "'";
                //4- Création de notre SqlDataReader
                SqlDataReader oDr;

                //5- Creation la command
                SqlCommand oCmd = new SqlCommand(query, oConn);

                //6- Exécution de la command
                oDr = oCmd.ExecuteReader();

                //7- Parcourir les données renvoyées
                //7.1 - Y'a-t-il des données ??
                if (oDr.HasRows)//retourne true si min 1 ligne dans notre reader
                {
                    //7.2- Boucle de parcours
                    while (oDr.Read()) //tant que je sais lire des données
                    {
                        //7.2.1- Construction de l'objet bien
                        b = b ?? new BienEchange();
                        b.Titre = oDr.GetString(0);
                        b.Latitude = oDr["Latitude"].ToString();
                        b.Longitude = oDr["Longitude"].ToString();


                        //7.3 - Fermer le datareader
                        oDr.Close();
                        //8- renvoi du bien
                        return b;
                    }
                }
                else
                {
                    //7.3 Pas de données donc fermeture 
                    // du datareader et renvoit de null
                    oDr.Close();
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

    }
}
        #endregion