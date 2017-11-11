using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
     class Depense
    {
        private int id;
        private float price;
        private string comment;
        private DateTime m_datetime;

        public float Price { get => price; set => price = value; }
        public string Comment { get => comment; set => comment = value; }
        public DateTime Datetime1 { get => m_datetime; set => m_datetime = value; }

        public Depense(int id, float price, string comment, DateTime m_dateTime)
        {
            this.id = id;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_dateTime;
        }
        public void hydrate(int id, float price, string comment, DateTime m_dateTime)
        {
            this.id = id;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_dateTime;
        }

    }
}
