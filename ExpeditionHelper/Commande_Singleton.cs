using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;

namespace ExpeditionHelper
{
    class Commande_Singleton
    {
        static private string server = "localhost";
        static private string user = "root";
        static private string password = "";
        static private string database = "testc#";
        static private string port = "3306";

        static private MySql.Data.MySqlClient.MySqlConnection connection;
        static private MySql.Data.MySqlClient.MySqlCommand commande;




        private static MySql.Data.MySqlClient.MySqlCommand instance=commande;

        private Commande_Singleton() { }
        public static void executeNonQuery()
        {
            if (instance != null)
            {
                commande.Prepare();
                commande.ExecuteNonQuery();
            }

        }
        public static MySql.Data.MySqlClient.MySqlCommand Instance
        {
            get
            {
                if (instance == null)
                {
                    connection = new MySql.Data.MySqlClient.MySqlConnection();
                    commande = new MySql.Data.MySqlClient.MySqlCommand();

                    string connStr = "server=" + server + ";user=" + user + ";database="
            + database + ";port=" + port + ";password=" + password + ";SslMode=none;IgnorePrepare=false";
                    connection.ConnectionString = connStr;
                    try
                    {
                        connection.Open();
                        commande.Connection = connection;
                    }
                    catch(MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
       
                }
                return instance;
            }
        }
    }
}
