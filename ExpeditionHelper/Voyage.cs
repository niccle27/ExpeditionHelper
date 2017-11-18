using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Voyage
    {
        private int id_Voyage;

        public int Id_Voyage
        {
            get { return id_Voyage; }
            set { id_Voyage = value; }
        }

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
        public Voyage(int id,string nom, DateTime debut, DateTime fin)
        {
            this.id_Voyage = id;
            this.nom = nom;
            this.debut = debut;
            this.fin = fin;
        }
        public void Hydrate(int id, string nom, DateTime debut, DateTime fin)
        {
            this.id_Voyage = id;
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
