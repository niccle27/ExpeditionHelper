using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Logique d'interaction pour WindowSearch.xaml
    /// </summary>
    public partial class WindowSearch : Window
    {
        public WindowSearch()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {

            string search = "https://weather.codes/search/?q="+tb_search.Text;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(search);
            HtmlNode node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/main/div/div[2]/div/div[3]/div/dl/dt[1]");
            if (node != null) MessageBox.Show(node.InnerText);
            else MessageBox.Show("an error occured, the code couldn't have been found");
                     
        }
    }
}
