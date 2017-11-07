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
    class Connection
    {
        static private string server = "localhost";
        static private string user = "root";
        static private string password = "";
        static private string database = "testc#";
        static private string port = "3306";

        static private MySql.Data.MySqlClient.MySqlConnection connection;

        private Connection() { }

        public static MySql.Data.MySqlClient.MySqlConnection getInstance()
        {
            if (connection == null)
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection();
                string connStr = "server=" + server + ";user=" + user + ";database="
        + database + ";port=" + port + ";password=" + password + ";SslMode=none;IgnorePrepare=false";
                connection.ConnectionString = connStr;
                try
                {
                    connection.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
            return connection;
        }
    }
}
