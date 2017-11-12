using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Nourriture :Depense
    {
        private int categorieNourriture;

        public Nourriture()
        {

        }
        public Nourriture(int id, float price, string comment, DateTime m_dateTime, int categorieNourriture) : base( id,  price,  comment,  m_dateTime)
        {
            this.categorieNourriture = categorieNourriture;
        }

        public int Categorie { get => categorieNourriture; set => categorieNourriture = value; }

        public void Hydrate(int id, float price, string comment, DateTime m_dateTime, int categorieNourriture)
        {
            base.Hydrate(id, price, comment, m_dateTime);
            this.categorieNourriture = categorieNourriture;
        }
    }
}
