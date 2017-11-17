using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Transport : Depense
    {
        private int id_Transport;

        public int Id_Transport
        {
            get { return id_Transport; }
            set { id_Transport = value; }
        }


        private string depart;

        public string Depart
        {
            get { return depart; }
            set { depart = value; }
        }

        private string  destination;

        public string  Destination
        {
            get { return destination; }
            set { destination = value; }
        }


        public Transport()
        {

        }
        public Transport(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string depart,string destination)
            : base(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime)
        {
            this.depart = depart;
            this.destination = destination;
        }

        public void Hydrate(int id_Depense, int Id_Voyage, int id_CategorieTable, float prix, string nom, string commentaire, DateTime m_dateTime, string depart,string destination)
        {
            base.Hydrate(id_Depense, Id_Voyage, id_CategorieTable, prix, nom, commentaire, m_dateTime);
            this.depart = depart;
            this.destination = destination;

        }
    }
}
