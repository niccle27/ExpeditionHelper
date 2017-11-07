using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpeditionHelper
{
    /// <summary>
    /// Logique d'interaction pour Window_spent.xaml
    /// </summary>
    public partial class Window_spent : Window
    {
        string category;

        public Window_spent(string category)
        {
            this.category = category;
            InitializeComponent();
        }

        private void btn_ok_spent_Click(object sender, RoutedEventArgs e)// à améliorer pour automatiser ce système
        {
            MySql.Data.MySqlClient.MySqlCommand commande=new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText= "insert into spent (`id`, `price`, `comment`) values(id, @price, @comment)";
                commande.Parameters.AddWithValue("@price", tb_price.Text);
                commande.Parameters.AddWithValue("@comment", tb_comment.Text);
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
