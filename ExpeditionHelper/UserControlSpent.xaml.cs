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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpeditionHelper
{
    /// <summary>
    /// Logique d'interaction pour UserControlSpent.xaml
    /// </summary>
    public partial class UserControlSpent : UserControl
    {
        Spent spent;
        public UserControlSpent(Spent spent)
        {
            this.spent = spent;
            InitializeComponent();
            lblPrice.Content = spent.Price.ToString();
            lblCategory.Content = spent.Category.ToString();
            tbComment.Text = spent.Comment;

        }
    }
}
