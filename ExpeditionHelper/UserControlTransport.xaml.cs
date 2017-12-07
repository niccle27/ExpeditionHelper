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
    /// Logique d'interaction pour UserControlTransport.xaml
    /// </summary>
    public partial class UserControlTransport : UserControl
    {
        public UserControlTransport(Transport transport)
        {
            InitializeComponent();
            tb_from.Text = transport.Depart;
            tb_to.Text = transport.Destination;
        }
        public UserControlTransport()
        {
            InitializeComponent();
        }
    }
}
