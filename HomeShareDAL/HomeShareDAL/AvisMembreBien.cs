using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public class AvisMembreBien
    {
        #region Fields
        private int _idAvis;
        private int _idBien;
        private string _message;
        private DateTime _dateAvis;
        private int _note;
        private bool _approuve;
        private int _idMembre;
        #endregion

        #region Properties
        public int IdAvis
        {
            get { return _idAvis; }
            set { _idAvis = value; }
        }

        public int IdBien
        {
            get { return _idBien; }
            set { _idBien = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public DateTime DateAvis
        {
            get { return _dateAvis; }
            set { _dateAvis = value; }
        }

        public int Note
        {
            get { return _note; }
            set { _note = value; }
        }

        public bool Approuve
        {
            get { return _approuve; }
            set { _approuve = value; }
        }

        public int IdMembre
        {
            get { return _idMembre; }
            set { _idMembre = value; }
        }
        #endregion

        #region Functions

        // Charger les avis d'un bien

        public static List<AvisMembreBien> ChargerAvisBien(int idB)
        {
            List<AvisMembreBien> retour = new List<AvisMembreBien>();

            List<Dictionary<string, object>> DesAvis = GestionConnexion.Instance.getData("select * from AvisMembreBien where idBien=" + idB);

            foreach (Dictionary<string, object> item in DesAvis)
            {
                AvisMembreBien a = new AvisMembreBien()
                {
                    IdBien = (int)item["idBien"],
                    IdAvis = (int)item["idAvis"],
                    Message = item["message"].ToString(),
                    DateAvis = (DateTime)item["DateAvis"],
                    Approuve = (bool)item["Approuve"],
                    Note = (int)item["note"],
                    IdMembre = (int)item["idMembre"]
                };

                retour.Add(a);
            }

            return retour;
        }

        // Ajouter un avis

        public static void AjouterAvis(int id, int txtMessage, int txtNote, DateTime txtDate)
        {
            string query = @"INSERT INTO [HomeShareMVCDB].[dbo].[AvisMembreBien]
([Message],[Note],[idMembre],[DateAvis]) VALUES (@message, @note, @idMembre,@DateAvis)";
            Dictionary<string, object> dicovalues = new Dictionary<string, object>();

            dicovalues.Add("Message", txtMessage);
            dicovalues.Add("Note", txtNote);
            dicovalues.Add("DateAvis", txtDate);
            dicovalues.Add("idMembre", id);

            GestionConnexion.Instance.saveData(query, GenerateKey.APP, dicovalues);

        }
        #endregion

    }
}
