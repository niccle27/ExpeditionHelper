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
            Activite tmp = new Activite(1, float.Parse(tb_price.Text), tb_comment.Text, DateTime.Now, tb_city.Text);
            ManagerSql.InsertActivity(tmp);
            ManagerSql.InsertDepense(tmp, 1);

            //UserControlSpent tmpU = new UserControlSpent(tmp);
            //((MainWindow)Application.Current.MainWindow).colonne1.Children.Add(tmpU);
            this.Close();
        }
    }
}
