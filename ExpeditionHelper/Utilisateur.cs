using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionHelper
{
    public class Utilisateur
    {
        public static event EventHandler Modification;
        protected static void OnModification(EventArgs e)
        {
            Modification?.Invoke(Instance, e);
            //equivalent
            /*if(Modification!=null)
            {
                Modification(this, e);
            }*/
        }

        static Utilisateur instance;

        private Voyage currentVoyage=null;

        public Voyage CurrentVoyage
        {
            get { return currentVoyage; }
            set { currentVoyage = value; }
        }
        public static bool IsConnected()
        {
            if (instance !=null &&instance.Id_utilisateur != 0)
            {
                return true;
            }
            else return false;
        }

        public Utilisateur()
        {

        }
        public Utilisateur(int id_utilisateur,string login,string password)
        {
            this.id_Utilisateur = id_utilisateur;
            this.login = login;
            this.password = password;
           // Instance.OnModification(EventArgs.Empty);
        }
        public void hydrate(int id_utilisateur, string login, string password)
        {
            this.id_Utilisateur = id_utilisateur;
            this.login = login;
            this.password = password;
            OnModification(EventArgs.Empty);
        }
        public void hydrate(Utilisateur utilisateur)
        {
            this.id_Utilisateur = utilisateur.Id_utilisateur;
            this.login = utilisateur.Login;
            this.password = utilisateur.Password;
            OnModification(EventArgs.Empty);
        }
        private int id_Utilisateur;
        public int Id_utilisateur
        {
            get { return id_Utilisateur; }
            set { id_Utilisateur = value;
            }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value;
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;
            }
        }
        public static Utilisateur resetInstance()
        {
            if (instance != null)
            {
                //instance = new Utilisateur();
                instance = null;
            }
            return instance;
        }

        public static Utilisateur Instance {
            get {
                if (instance == null)
                {
                    instance = new Utilisateur();
                }
                return instance;
            }
            set {  instance = value;
               // instance.OnModification(EventArgs.Empty);
            }
        }
    }
}
