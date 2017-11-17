using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    class Utilisateur
    {
        public Utilisateur()
        {

        }
        public Utilisateur(int id_utilisateur,string login,string password)
        {
            this.id_Utilisateur = id_utilisateur;
            this.login = login;
            this.password = password;
        }
        public void hydrate(int id_utilisateur, string login, string password)
        {
            this.id_Utilisateur = id_utilisateur;
            this.login = login;
            this.password = password;
        }
        private int id_Utilisateur;
        public int Id_utilisateur
        {
            get { return id_Utilisateur; }
            set { id_Utilisateur = value; }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }



    }
}
