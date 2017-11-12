using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Logement: Depense
    {
        private string ville;
        private int categorieLogement;

        public Logement()
        {

        }
        public Logement(int id, float price, string comment, DateTime m_dateTime,string ville,int categorieLogement)
            : base( id,  price,  comment,  m_dateTime)
        {
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }

        public string Ville { get => ville; set => ville = value; }
        public int CategorieLogement { get => categorieLogement; set => categorieLogement = value; }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, string ville, int categorieLogement)
        {
            base.Hydrate(id, price, comment, m_dateTime);
            this.ville = ville;
            this.categorieLogement = categorieLogement;
        }
    }
}
