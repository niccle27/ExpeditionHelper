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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpeditionHelper
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            colonne1.Children.Clear();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "select category.nom,price,comment from spent left join category on spent.id=category.id_category";
            cmd.Connection = Connection.getInstance();
            cmd.CommandTimeout = 60;
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                object[] values = new object[3];
                reader.GetValues(values);
                Spent tmp = new Spent(Convert.ToInt32(values[0]), Convert.ToSingle(values[1]), values[2].ToString());
                UserControlSpent userControlSpent_tmp = new UserControlSpent(tmp);
                colonne1.Children.Add(userControlSpent_tmp);
            }
        }


        private void btn_new_activities_Click(object sender, RoutedEventArgs e)
        {
            WindowSpentEntry tmp = new WindowSpentEntry((int)Spent.categories.activity);
            tmp.ShowDialog();
        }

        private void btn_new_meal_Click(object sender, RoutedEventArgs e)
        {
            WindowSpentEntry tmp = new WindowSpentEntry((int)Spent.categories.meal);
            tmp.ShowDialog();
        }

        private void btn_new_transport_Click(object sender, RoutedEventArgs e)
        {
            WindowSpentEntry tmp = new WindowSpentEntry((int)Spent.categories.transport);
            tmp.ShowDialog();
        }

        private void btn_new_others_Click(object sender, RoutedEventArgs e)
        {
            WindowSpentEntry tmp = new WindowSpentEntry((int)Spent.categories.other);
            tmp.ShowDialog();
        }

        private void MI_connection_Click(object sender, RoutedEventArgs e)
        {
            Window_connection tmp = new Window_connection();
            tmp.ShowDialog();
        }
    }
}
