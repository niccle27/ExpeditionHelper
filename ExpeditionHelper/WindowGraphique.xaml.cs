using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour WindowGraphique.xaml
    /// </summary>
    public partial class WindowGraphique : Window
    {
        ObservableCollection<KeyValuePair<string, int>> collection_Categorie_Value;
        public ObservableCollection<KeyValuePair<string, int>> Collection_Categorie_Value { get => collection_Categorie_Value; set => collection_Categorie_Value = value; }

        public WindowGraphique(int id_voyage)
        {
            InitializeComponent();
            Collection_Categorie_Value = ManagerSql.SelectDataGraphiqueVoyage(id_voyage);
            this.DataContext = this;
        }
    }
}
