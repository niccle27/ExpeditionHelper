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
            ManagerSql.hydrateCategorie();
            InitializeComponent();
            refresh();
            // juste pour test
            
            List<Voyage> test = new List<Voyage>();
            liste_Voyage.ItemsSource = test;
            test.Add(new Voyage("belgique",new DateTime(2014,1,1),new DateTime(2014, 1, 10)));
            test.Add(new Voyage("france", new DateTime(2014, 1, 1), new DateTime(2014, 1, 10)));


        }
        public void refresh()
        {
            /*colonne1.Children.Clear();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "select id_category,price,comment from spent";
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
            Connection.getInstance().Dispose();*/
        }


        private void new_activities(object sender, RoutedEventArgs e)
        {
            WindowActivites tmp = new WindowActivites();
            tmp.ShowDialog();
        }

        private void new_meal(object sender, RoutedEventArgs e)
        {
            WindowNourriture tmp = new WindowNourriture();
            tmp.ShowDialog();
        }

        private void new_transport(object sender, RoutedEventArgs e)
        {
            WindowTransport tmp = new WindowTransport();
            tmp.ShowDialog();
        }
        private void new_logement(object sender, RoutedEventArgs e)
        {
            WindowLogement tmp = new WindowLogement();
            tmp.ShowDialog();
        }
        private void new_divers(object sender, RoutedEventArgs e)
        {
            WindowDivers tmp = new WindowDivers();
            tmp.ShowDialog();
        }

        private void MI_connection_Click(object sender, RoutedEventArgs e)
        {
            Window_connection tmp = new Window_connection();
            tmp.ShowDialog();
        }
        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }


    }
}
