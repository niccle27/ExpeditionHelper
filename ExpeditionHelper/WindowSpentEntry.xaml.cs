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
    /// Logique d'interaction pour WindowSpentEntry.xaml
    /// </summary>
    public partial class WindowSpentEntry : Window
    {
        Spent.categories category;

        public WindowSpentEntry(Spent.categories category)
        {
            this.category = category;
            InitializeComponent();
        }

        private void btn_ok_spent_Click(object sender, RoutedEventArgs e)// à améliorer pour automatiser ce système
        {
            Spent tmp = new Spent(category,float.Parse(this.tb_price.Text),this.tb_comment.Text);
            ManagerSql.InsertSpent(tmp);
           
            this.Close();
        }
    }
}
