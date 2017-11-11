using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Nourriture :Depense
    {
        private int categorie;

        public Nourriture()
        {

        }
        public Nourriture(int id, float price, string comment, DateTime m_dateTime, int categorie) : base( id,  price,  comment,  m_dateTime)
        {
            this.categorie = categorie;
        }

        public int Categorie { get => categorie; set => categorie = value; }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, int categorie)
        {
            base.Hydrate(id, price, comment, m_dateTime);
            this.categorie = categorie;
        }
    }
}
