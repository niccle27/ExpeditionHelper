﻿using System;
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
    /// Logique d'interaction pour WindowLogement.xaml
    /// </summary>
    public partial class WindowLogement : Window
    {
        public WindowLogement()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            Logement tmp = new Logement(0, Utilisateur.Instance.CurrentVoyage.Id_Voyage,2,
                float.Parse(userControlDepense.tb_price.Text), userControlDepense.tb_name.Text, userControlDepense.tb_comment.Text, DateTime.Now,
                userControlLogement.tb_city.Text,userControlLogement.cb_categorie.Text);
            ManagerSql.InsertLogement(tmp);
            ManagerSql.InsertDepense(tmp);
            Utilisateur.Instance.CurrentVoyage.refreshListeDepense();
            this.Close();
        }
    }
}
