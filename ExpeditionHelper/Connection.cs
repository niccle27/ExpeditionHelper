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
        static private string database = "eh";
        static private string port = "3306";

        static private MySql.Data.MySqlClient.MySqlConnection connection=null;

        private Connection() { }

        public static MySql.Data.MySqlClient.MySqlConnection getInstance()
        {                string connStr = "server=" + server + ";user=" + user + ";database="
        + database + ";port=" + port + ";password=" + password + ";SslMode=none;IgnorePrepare=false";
            if (connection == null || connection.State==System.Data.ConnectionState.Closed)
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection(connStr);

               // connection.ConnectionString = connStr;
                try
                {
                    connection.Open();
                    ((MainWindow)Application.Current.MainWindow).connectionBall.Fill = Brushes.Green;
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
