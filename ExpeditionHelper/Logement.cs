using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Logement: Depense
    {
        /* private string ville;
         private int categorieLogement;*/
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
        public Logement(int id, float price, string comment, DateTime m_dateTime,string ville,int categorieLogement)
            : base( id,  price,  comment,  m_dateTime)
        {
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, string ville, int categorieLogement)
        {
            base.Hydrate(id, price, comment, m_dateTime);
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }
    }
}
