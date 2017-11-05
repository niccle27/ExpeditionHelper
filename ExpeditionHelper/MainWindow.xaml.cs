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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_new_activities_Click(object sender, RoutedEventArgs e)
        {
            Window_spent tmp = new Window_spent("activity");
            tmp.ShowDialog();
        }

        private void btn_new_meal_Click(object sender, RoutedEventArgs e)
        {
            Window_spent tmp = new Window_spent("meal");
            tmp.ShowDialog();
        }

        private void btn_new_transport_Click(object sender, RoutedEventArgs e)
        {
            Window_spent tmp = new Window_spent("transport");
            tmp.ShowDialog();
        }

        private void btn_new_others_Click(object sender, RoutedEventArgs e)
        {
            Window_spent tmp = new Window_spent("other");
            tmp.ShowDialog();
        }

        private void MI_connection_Click(object sender, RoutedEventArgs e)
        {
            Window_connection tmp = new Window_connection();
            tmp.ShowDialog();
        }
    }
}
