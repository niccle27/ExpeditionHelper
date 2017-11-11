using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{

    class Activite:Depense
    {
        public Activite()
        {

        }
        public Activite(int id, float price, string comment, DateTime m_dateTime, string depart, string destination) : base( id,  price,  comment,  m_dateTime)
        {

        }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, string depart, string destination)
        {
            base.Hydrate(id, price, comment, m_dateTime); 
        }
    }
}
