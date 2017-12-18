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
    /// Logique d'interaction pour WindowTransport.xaml
    /// </summary>
    public partial class WindowTransport : Window
    {
        public WindowTransport()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (Utilisateur.IsConnected())
            {
                try
                {
                    /*Transport tmp = new Transport(0, Utilisateur.Instance.CurrentVoyage.Id_Voyage, 0, float.Parse(userControlDepense.tb_price.Text), userControlDepense.tb_name.Text, userControlDepense.tb_comment.Text,
                    DateTime.Now, userControlTransport.tb_from.Text, userControlTransport.tb_to.Text);*/
                    ManagerSql.InsertTransport((Transport)DataContext);
                    ManagerSql.InsertDepense((Transport)DataContext);
                    Utilisateur.Instance.CurrentVoyage.refreshListeDepense();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("an error occured, please retry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else MessageBox.Show("You are not connected!");

            this.Close();
        }
    }
}
