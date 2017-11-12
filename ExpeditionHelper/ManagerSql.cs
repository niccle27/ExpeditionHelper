using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpeditionHelper
{
    public class ManagerSql
    {
        public static void hydrateCategorie()
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "SELECT nomTable,id_categorie FROM categories";
            cmd.Connection = Connection.getInstance();
            cmd.CommandTimeout = 60;
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Depense.categorieTable.Add(reader.GetValue(0).ToString(), (int)reader.GetValue(1));
            }
            Connection.getInstance().Dispose();
        }

        public static void InsertSpent(Spent spent)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText = "insert into spent (`id`,`id_category`, `price`, `comment`) values(id,@category, @price, @comment)";
                commande.Parameters.AddWithValue("@price", spent.Price);
                commande.Parameters.AddWithValue("@category", spent.Category);
                commande.Parameters.AddWithValue("@comment", spent.Comment);
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Connection.getInstance().Dispose();

        }
        public static void InsertDepense(Depense depense)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "insert into depenses (m_datetime, id_voyage, id_categorie, id_subCat, prix, nom)"+
                    " VALUES(NOW(),1,@id_categorie,LAST_INSERT_ID(),@price,@comment)";
                commande.Parameters.AddWithValue("@price", depense.Price);
                commande.Parameters.AddWithValue("@comment", depense.Comment);
                commande.Parameters.AddWithValue("@id_categorie", depense.findCategorie());
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Connection.getInstance().Dispose();

        }
        public static void InsertActivity(Activite activite)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "INSERT INTO `activites`(`id_categorie`, `ville`) " +
                    "VALUES (@id_categorie,@ville)";
                commande.Parameters.AddWithValue("@id_categorie", Depense.categorieTable["activite"]);
                commande.Parameters.AddWithValue("@ville",activite.Ville);
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Connection.getInstance().Dispose();

        }
        public static void InsertLogement(Logement logement)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "INSERT INTO `logements`(`ville`, `id_CategorieLogement`) " +
                    "VALUES (@ville,@id_CategorieLogement)";
                commande.Parameters.AddWithValue("@id_CategorieLogement", 1);
                commande.Parameters.AddWithValue("@ville", logement.Ville);
                commande.Prepare();
                commande.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Connection.getInstance().Dispose();

        }
    }
}
