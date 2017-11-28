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
    /// Logique d'interaction pour UserControlDepense.xaml
    /// </summary>
    public partial class UserControlDepense : UserControl
    {
        public UserControlDepense(Depense depense)
        {
            InitializeComponent();
            tb_name.Text = depense.Nom;
            tb_price.Text = depense.Prix.ToString();
            tb_comment.Text = depense.Commentaire;
        }
        public UserControlDepense()
        {
            InitializeComponent();
        }
    }
}
