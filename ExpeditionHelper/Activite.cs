using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{

    class Activite
    {
        private string category;
        private float price;
        private string comment;
        private DateTime m_datetime;

        public string Category { get => category; set => category = value; }
        public float Price { get => price; set => price = value; }
        public string Comment { get => comment; set => comment = value; }
        public DateTime Datetime1 { get => m_datetime; set => m_datetime = value; }

        public Activite()
        {

        }
        public Activite(string category, float price, string comment, DateTime m_datetime)
        {
            this.category = category;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_datetime;
        }
        public void hydrate(string category, float price, string comment, DateTime m_datetime)
        {
            this.category = category;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_datetime;
        }
    }
}
