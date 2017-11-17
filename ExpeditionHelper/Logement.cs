using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Logement: Depense
    {
        private int id_logement;

        public int Id_logement
        {
            get { return id_logement; }
            set { id_logement = value; }
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
