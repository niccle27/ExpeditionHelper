using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Transport : Depense
    {
        private int id_Transport;

        public int Id_Transport
        {
            get { return id_Transport; }
            set { id_Transport = value; }
        }


        private string depart;

        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }

        private string  destination;

        public string  Destination
        {
            get { return destination; }
            set { destination = value; }
        }


        public Transport()
        {

        }
        public Transport(int id, float price, string comment, DateTime m_dateTime, string depart,string destination) : base( id,  price,  comment,  m_dateTime)
        {
            this.depart = depart;
            this.destination = destination;
        }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime,string depart,string destination)
        {
            base.Hydrate( id,  price,  comment,  m_dateTime);
            this.depart = depart;
            this.destination = destination;

        }
    }
}
