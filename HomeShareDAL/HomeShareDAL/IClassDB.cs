using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeShareDAL
{
    public interface IClassDB<T>

         where T : class
    {

        /// <summary>

        /// Permet de sauver l'instance T dans la DB (Insert/Update)

        /// </summary>

        /// <returns>True si les modifications ont pu être effectuées</returns>

        bool Sauvegarder();

        /// <summary>

        /// Permet de supprimer l'instance T de la DB

        /// </summary>

        /// <returns>True si la suppression a pu être effectuée</returns>

        bool Supprimer();



        /// <summary>

        /// Permet de lier les valeurs du dictionnaire en paramètre aux propriété de l'objet de type T

        /// </summary>

        /// <param name="Datas">Les valeurs permettant de remplir les propriétés de l'objet de type T </param>

        void associe(Dictionary<string, object> Datas);

    }

}