using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //List<Voyage> listeDeVoyage = new List<Voyage>();
        ObservableCollection<Voyage> listeDeVoyage = new ObservableCollection<Voyage>();

        public void OnUtilisateurModification(Object sender, EventArgs e)
        {
            ReLoad();
           
        }


        public MainWindow()
        {
            ManagerSql.HydrateCategorie();
            Utilisateur.Instance.Modification += OnUtilisateurModification;
            InitializeComponent();
            //remodifier ça et passer en xaml => code behind pas propre
            listView_Voyage.ItemsSource = listeDeVoyage;
            listView_Voyage.SelectedIndex = 0;

        }

        public void ReLoad()
        {
            ManagerSql.SelectVoyages(listeDeVoyage);// refresh automatique via observableCollection           
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

        private void listView_Voyage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
            view1.GroupDescriptions.Clear();
            Utilisateur.Instance.CurrentVoyage = (Voyage)listView_Voyage.SelectedItem;
            CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Date");
            view2.GroupDescriptions.Add(groupDescription);
        }

        
    }
}
