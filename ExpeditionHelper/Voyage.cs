using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    class Voyage
    {
       // DateTime fin;
       // List<Depense> listeDepense = new List<Depense>();
        private string nom;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private DateTime debut;
        public DateTime Debut
        {
            get { return debut; }
            set { debut = value; }
        }

        private DateTime fin;
        public DateTime Fin
        {
            get { return fin; }
            set { fin = value; }
        }

       private List<Depense> listeDepense = new List<Depense>();
       public List<Depense> ListeDepense
        {
            get { return listeDepense; }
            set { listeDepense = value; }
        }



        public Voyage()
        {

        }
        public Voyage(string nom, DateTime debut, DateTime fin)
        {
            this.nom = nom;
            this.debut = debut;
            this.fin = fin;
        }
        public void Hydrate(string nom, DateTime debut, DateTime fin)
        {
            this.nom = nom;
            this.debut = debut;
            this.fin = fin;
        }
        public void AddList(List<Depense> additionnalList)
        {
            ListeDepense.AddRange(additionnalList);
        }
        public void AddDepense(Depense depense)
        {
            ListeDepense.Add(depense);
        }
        
    }
}
