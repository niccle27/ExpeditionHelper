using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Spent
    {
        public enum categories{ other,activity, meal,transport};

        private categories category;
        private float price;
        private string comment;

        public categories Category { get => category; set => category = value; }
        public float Price { get => price; set => price = value; }
        public string Comment { get => comment; set => comment = value; }

        public Spent()//shortcutt c# ctor + tab+tab to create a constructor
        {

        }
        public Spent(categories category, float price,string comment)
        {
            this.category = category;
            this.price = price;
            this.comment = comment;
        }
        public void hydrate(categories category, float price, string comment)
        {
            this.category = category;
            this.price = price;
            this.comment = comment;
        }
        
    }
}
