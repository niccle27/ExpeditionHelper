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
    /// Logique d'interaction pour Window_connection.xaml
    /// </summary>
    public partial class Window_connection : Window
    {
        public Window_connection()
        {
            InitializeComponent();
        }

        private void btn_connection_Click(object sender, RoutedEventArgs e)
        {
            Utilisateur tmp = new Utilisateur(0, tb_login.Text, tb_password.Text);
            ManagerSql.Connection_Utilisateur(tmp);
        }
    }
}
