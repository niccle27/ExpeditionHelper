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
    /// Logique d'interaction pour WindowVoyage.xaml
    /// </summary>
    public partial class WindowVoyage : Window
    {
        public WindowVoyage()
        {
            InitializeComponent();

        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (Utilisateur.IsConnected())
            {
                try
                {
                    ManagerSql.InsertVoyage((Voyage)DataContext);
                    MainWindow.ReLoad();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("an error occured, please retry","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }

            }
            else MessageBox.Show("You are not connected!");
            this.Close();
        }
    }
}
