using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        static ObservableCollection<Voyage> listeDeVoyage = new ObservableCollection<Voyage>();

        public void OnUtilisateurModification(Object sender, EventArgs e)
        {
            ReLoad();
           
        }
        public static void ResetListeDeVoyage()
        {
            listeDeVoyage.Clear();
        }

        public MainWindow()
        {
            Utilisateur.Modification += OnUtilisateurModification;// link OnUtilisateurModification à l'événement utilisateur

            
            InitializeComponent();
            ManagerSql.HydrateCategorie();//hydrater les categories
            listView_Voyage.ItemsSource = listeDeVoyage;
            listView_Voyage.SelectedIndex = 0;

        }

        public static void ReLoad()
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
            try
            {
                CollectionView view1 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
                view1.GroupDescriptions.Clear();//artifice pour empêcher d'imbriquer des groupe en rapellant la fonction
                view1.SortDescriptions.Clear();
                Utilisateur.Instance.CurrentVoyage = (Voyage)listView_Voyage.SelectedItem;
                CollectionView view2 = (CollectionView)CollectionViewSource.GetDefaultView(listView_Depense.ItemsSource);
                SortDescription sortDescription = new SortDescription("M_datetime", ListSortDirection.Ascending);
                view2.SortDescriptions.Add(sortDescription);
                PropertyGroupDescription groupDescription = new PropertyGroupDescription("Date");
                view2.GroupDescriptions.Add(groupDescription);
            }
            catch (Exception)
            {
                //ne rien faire c'est que la liste est vide
            }
            //bug le sort ne s'effecture pas 
        }

        private void listView_Depense_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btn_update.Visibility = Visibility.Visible;
            edit_zone.Children.Clear();
            var tmp = ((ListView)sender).SelectedItem;
            if (tmp is Activite)
            {

                Activite tmp2 = tmp as Activite;
                UserControlActivite userControlActivite = new UserControlActivite();
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Logement)
            {
                Logement tmp2 = tmp as Logement;
                UserControlLogement userControlActivite = new UserControlLogement(tmp2);
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Transport)
            {
                Transport tmp2 = tmp as Transport;
                UserControlTransport userControlActivite = new UserControlTransport(tmp2);
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Nourriture)
            {
                Nourriture tmp2 = tmp as Nourriture;
                UserControlNourriture userControlActivite = new UserControlNourriture();
                userControlActivite.DataContext = tmp2;
                edit_zone.Children.Add(userControlActivite);
                Grid.SetRow(userControlActivite, 0);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }
            else if (tmp is Depense)
            {
                Depense tmp2 = tmp as Depense;
                //UserControlDepense userControlDepense = new UserControlDepense(tmp2);
                UserControlDepense userControlDepense = new UserControlDepense();
                userControlDepense.DataContext = tmp2;
                edit_zone.Children.Add(userControlDepense);
                Grid.SetRow(userControlDepense, 1);
            }

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            var tmp = listView_Depense.SelectedItem;
            if (tmp is Activite)
            {
                Activite tmp2 = tmp as Activite;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateActivity(tmp2);
            }
            else if (tmp is Logement)
            {
                Logement tmp2 = tmp as Logement;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateLogement(tmp2);
            }
            else if (tmp is Transport)
            {
                Transport tmp2 = tmp as Transport;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateTransport(tmp2);
            }
            else if (tmp is Nourriture)
            {
                Nourriture tmp2 = tmp as Nourriture;
                ManagerSql.UpdateDepense(tmp2);
                ManagerSql.UpdateNourriture(tmp2);
            }
            else if (tmp is Depense)
            {
                Depense tmp2 = tmp as Depense;
                ManagerSql.UpdateDepense(tmp2);
            }
            ManagerSql.SelectDepenseTot((Voyage)listView_Voyage.SelectedItem);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContextMenuRemove_btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerSql.DeleteAnyDepense((Depense)listView_Depense.SelectedItem);
            ((Voyage)listView_Voyage.SelectedItem).refreshListeDepense();
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This software was develloped by Clément Nicolas");
        }

        private void MI_Disconnection_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur.resetInstance();
            ResetListeDeVoyage();
        }

        private void btn_new_trip_Click(object sender, RoutedEventArgs e)
        {
            Voyage voyage = new Voyage();
            WindowVoyage tmp = new WindowVoyage();
            tmp.DataContext = voyage;
            tmp.ShowDialog();
        }

        private void ContextMenuRemoveVoyage_btn_Click(object sender, RoutedEventArgs e)
        {
            ManagerSql.DeleteVoyage((Voyage)listView_Voyage.SelectedItem);
            ReLoad();
        }
    }
}
