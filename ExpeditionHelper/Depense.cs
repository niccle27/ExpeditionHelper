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

        private int id_depense;

        public int Id_depense
        {
            get { return id_depense; }
            set { id_depense = value; }
        }


        private int id_categorieTable;
        public int Id_categorieTable
        {
            get { return id_categorieTable; }
            set { id_categorieTable = value; }
        }

        private int depenseCategorie;
        public int DepenseCategorie
        {
            get { return depenseCategorie; }
            set { depenseCategorie = value; }
        }

        private float prix;
        public float Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        private string commentaire;

        public string Commentaire
        {
            get { return commentaire; }
            set { commentaire = value; }
        }
        private DateTime m_datetime;

        public DateTime M_datetime
        {
            get { return m_datetime; }
            set { m_datetime = value; }
        }


        public string GetCategorieTableName()
        {
            if (depenseCategorie == 0) findCategorie();
                foreach (var element in categorieTable)
                {
                    if (element.Value == Id_categorieTable) return element.Key;
                }
            return "NULL";
        }

        public Depense()
        {

        }

        public Depense(int id, float prix, string commentaire, DateTime m_dateTime)
        {
            this.id_categorieTable = id;
            this.Prix = prix;
            this.commentaire = commentaire;
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

        public void Hydrate(int id, float prix, string commentaire, DateTime m_dateTime)
        {
            this.id_categorieTable = id;
            this.Prix = prix;
            this.commentaire = commentaire;
            this.m_datetime = m_dateTime;
        }

    }
}
