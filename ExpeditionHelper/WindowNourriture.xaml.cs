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
            Nourriture tmp = new Nourriture(0,1,0, float.Parse(userControlDepense.tb_price.Text), userControlDepense.tb_name.Text, userControlDepense.tb_comment.Text,
                DateTime.Now, userControlNourriture.cb_categorie.Text);
            ManagerSql.InsertNourriture(tmp);
            ManagerSql.InsertDepense(tmp);
            this.Close();
        }
    }
}
