using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{

    public class Activite :Depense
    {
        private int id_Activite;

        public int Id_Activite
        {
            get { return id_Activite; }
            set { id_Activite = value; }
        }


        private string ville;
        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }


        public Activite()
        {

        }
        public Activite(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string ville)
            : base( id_Depense,  Id_Voyage,  id_CategorieTable,  prix,  nom,  commentaire,  m_dateTime)
        {
            this.ville = ville;
        }

        public void Hydrate(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string ville)
        {
            base.Hydrate(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime);
            this.ville = ville;
        }
    }
}
