using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
     public class Depense
    {
        public static Dictionary<string, int> categorieTable = new Dictionary<string, int>();


        private int id;
        private int depenseCategorie;
        private float price;
        private string comment;
        private DateTime m_datetime;

        public float Price { get => price; set => price = value; }
        public string Comment { get => comment; set => comment = value; }
        public DateTime Datetime1 { get => m_datetime; set => m_datetime = value; }
        public int Id { get => id; set => id = value; }
        public int DepenseCategorie { get => depenseCategorie; set => depenseCategorie = value; }

        public Depense()
        {

        }

        public Depense(int id, float price, string comment, DateTime m_dateTime)
        {
            this.Id = id;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_dateTime;
        }
        public int findCategorie()
        {
            if (this is Activite) depenseCategorie = categorieTable["activite"];
            else if (this is Logement) depenseCategorie = categorieTable["logement"];
            else if (this is Transport) depenseCategorie = categorieTable["transport"];
            else if (this is Nourriture) depenseCategorie = categorieTable["nourriture"];
            else if (this is Depense) depenseCategorie = categorieTable["divers"];
            return depenseCategorie;
        }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime)
        {
            this.Id = id;
            this.price = price;
            this.comment = comment;
            this.m_datetime = m_dateTime;
        }

    }
}
