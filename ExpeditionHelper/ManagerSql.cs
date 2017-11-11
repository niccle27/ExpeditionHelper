using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpeditionHelper
{
    public class ManagerSql
    {
        public static void InsertSpent(Spent spent)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText = "insert into spent (`id`,`id_category`, `price`, `comment`) values(id,@category, @price, @comment)";
                commande.Parameters.AddWithValue("@price", spent.Price);
                commande.Parameters.AddWithValue("@category", spent.Category);
                commande.Parameters.AddWithValue("@comment", spent.Comment);
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
