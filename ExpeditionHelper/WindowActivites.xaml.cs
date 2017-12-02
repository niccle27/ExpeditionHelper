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
    /// Logique d'interaction pour WindowActivites.xaml
    /// </summary>
    public partial class WindowActivites : Window
    {
        public WindowActivites()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            if (Utilisateur.IsConnected())
            {
                Activite tmp = new Activite(0,Utilisateur.Instance.CurrentVoyage.Id_Voyage,0,float.Parse(userControlDepense.tb_price.Text), userControlDepense.tb_name.Text, userControlDepense.tb_comment.Text,
                DateTime.Now, userControlActivite.tb_city.Text);
                ManagerSql.InsertActivity(tmp);
                ManagerSql.InsertDepense(tmp);
                Utilisateur.Instance.CurrentVoyage.refreshListeDepense();
            }
            else MessageBox.Show("You are not connected!");
            this.Close();
        }
    }
}
