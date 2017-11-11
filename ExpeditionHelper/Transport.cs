using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    class Transport : Depense
    {
        private string depart;
        private string destination;

        public Transport()
        {

        }
        public Transport(int id, float price, string comment, DateTime m_dateTime, string depart,string destination) : base( id,  price,  comment,  m_dateTime)
        {
            this.depart = depart;
            this.destination = destination;
        }

        public string Depart { get => depart; set => depart = value; }
        public string Destination { get => destination; set => destination = value; }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime,string depart,string destination)
        {
            base.Hydrate( id,  price,  comment,  m_dateTime);
            this.depart = depart;
            this.destination = destination;

        }
    }
}
