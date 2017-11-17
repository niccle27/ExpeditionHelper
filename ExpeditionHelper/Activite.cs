using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{

    public class Activite :Depense
    {
        private int id_activite;

        public int Id_activite
        {
            get { return id_activite; }
            set { id_activite = value; }
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
        public Activite(int id, float price, string comment, DateTime m_dateTime, string ville) : base( id,  price,  comment,  m_dateTime)
        {
            this.ville = ville;
        }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, string ville)
        {
            base.Hydrate(id, price, comment, m_dateTime);
            this.ville = ville;
        }
    }
}
