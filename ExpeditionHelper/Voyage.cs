using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    class Voyage
    {
        string nom;
        DateTime debut;
        DateTime fin;
        List<Depense> listeDepense = new List<Depense>();

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
        public string Nom { get => nom; set => nom = value; }
        public DateTime Debut { get => debut; set => debut = value; }
        public DateTime Fin { get => fin; set => fin = value; }
        public List<Depense> ListeDepense { get => listeDepense; set => listeDepense = value; }
    }
}
