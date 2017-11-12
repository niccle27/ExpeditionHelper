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
    /// Logique d'interaction pour WindowNourriture.xaml
    /// </summary>
    public partial class WindowNourriture : Window
    {
        public WindowNourriture()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            Nourriture tmp = new Nourriture(1, float.Parse(tb_price.Text), tb_comment.Text, DateTime.Now,1);
            ManagerSql.InsertNourriture(tmp);
            ManagerSql.InsertDepense(tmp);

            //UserControlSpent tmpU = new UserControlSpent(tmp);
            //((MainWindow)Application.Current.MainWindow).colonne1.Children.Add(tmpU);
            this.Close();
        }
    }
}
