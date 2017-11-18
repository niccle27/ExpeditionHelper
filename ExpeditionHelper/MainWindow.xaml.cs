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
        List<Voyage> listeDeVoyage = new List<Voyage>();

        public void OnUtilisateurModification(Object sender, EventArgs e)
        {
            ReLoad();
        }


        public MainWindow()
        {
            ManagerSql.HydrateCategorie();
            Utilisateur.Instance.Modification += OnUtilisateurModification;
            InitializeComponent();
            listView_Voyage.ItemsSource = listeDeVoyage;
            // juste pour test

            
             
             /*test.Add(new Voyage("belgique",new DateTime(2014,1,1),new DateTime(2014, 1, 10)));
             test.Add(new Voyage("france", new DateTime(2014, 1, 1), new DateTime(2014, 1, 10)));*/


        }

        public void ReLoad()
        {
            listeDeVoyage=ManagerSql.SelectVoyages();
            listView_Voyage.ItemsSource = listeDeVoyage;
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
    }
}
