using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Logement: Depense
    {
        private int id_Logement;

        public int Id_Logement
        {
            get { return id_Logement; }
            set { id_Logement = value; }
        }


        private string ville;

        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        private int categorieLogement;

        public int CategorieLogement
        {
            get { return categorieLogement; }
            set { categorieLogement = value; }
        }


        public Logement()
        {

        }
        public Logement(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string ville,int categorieLogement)
            : base(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime)
        {
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }

        public void Hydrate(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string ville, int categorieLogement)
        {
            base.Hydrate(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime);
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }
    }
}
