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

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }


        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }


        private int id_Voyage;

        public int Id_Voyage
        {
            get { return id_Voyage; }
            set { id_Voyage = value; }
        }


        private int id_Depense;

        public int Id_Depense
        {
            get { return id_Depense; }
            set { id_Depense = value; }
        }


        private int id_subCat;
        public int Id_subCat
        {
            get { return id_subCat; }
            set { id_subCat = value; }
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
            set { m_datetime = value;
                this.date = value.Date.ToString("MM/dd/yyyy");
            }
        }


        /*public string GetCategorieTableName()
        {
            if (depenseCategorie == 0) findCategorie();
                foreach (var element in categorieTable)
                {
                    if (element.Value == id_CategorieTable) return element.Key;
                }
            return "NULL";
        }*/

        public Depense()
        {

        }

        public Depense(int id_Depense,int Id_Voyage, int Id_subCat, float prix,string nom, string commentaire, DateTime m_dateTime)
        {
            this.nom = nom;
            this.id_Voyage = Id_Voyage;
            this.id_Depense = id_Depense;
            this.Id_subCat = Id_subCat;
            this.Prix = prix;
            this.commentaire = commentaire;
            this.M_datetime = m_dateTime;
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

        public void Hydrate(int id_Depense, int Id_Voyage, int Id_subCat, float prix, string nom, string commentaire, DateTime m_dateTime)
        {
            this.nom = nom;
            this.id_Voyage = Id_Voyage;
            this.id_Depense = id_Depense;
            this.Id_subCat = Id_subCat;
            this.Prix = prix;
            this.commentaire = commentaire;
            this.M_datetime = m_dateTime;
            
        }

    }
}
