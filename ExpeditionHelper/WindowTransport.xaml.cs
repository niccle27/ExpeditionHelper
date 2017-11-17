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
            Transport tmp = new Transport(0, 1, 0, float.Parse(tb_price.Text), tb_name.Text, tb_comment.Text, DateTime.Now, tb_from.Text,tb_to.Text);
            ManagerSql.InsertTransport(tmp);
            ManagerSql.InsertDepense(tmp);
            this.Close();
        }
    }
}
