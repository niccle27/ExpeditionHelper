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
    /// Logique d'interaction pour UserControlActivite.xaml
    /// </summary>
    public partial class UserControlActivite : UserControl
    {
        public UserControlActivite(Activite activite)
        {
            InitializeComponent();
            tb_city.Text = activite.Ville;
        }
        public UserControlActivite()
        {
            InitializeComponent();
        }
    }
}
