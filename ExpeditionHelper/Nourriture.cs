using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Nourriture :Depense
    {
        private int id_Nourriture;

        public int Id_Nourriture
        {
            get { return id_Nourriture; }
            set { id_Nourriture = value; }
        }

        private int categorieNourriture;

        public int CategorieNourriture
        {
            get { return categorieNourriture; }
            set { categorieNourriture = value; }
        }


        public Nourriture()
        {

        }
        public Nourriture(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, int categorieNourriture)
            : base(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime)
        {
            this.categorieNourriture = categorieNourriture;
        }

        public void Hydrate(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, int categorieNourriture)
        {
            base.Hydrate(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime);
            this.categorieNourriture = categorieNourriture;
        }
    }
}
