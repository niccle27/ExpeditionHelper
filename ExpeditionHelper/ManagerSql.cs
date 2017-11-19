using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExpeditionHelper
{
    public class ManagerSql
    {
        //select
        public static void SelectDivers(Voyage voyage)
        {//non testé
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "SELECT `id_depense`, `id_voyage`, `id_categorie`, `prix`, `nom`, `commentaire`,UNIX_TIMESTAMP(`m_datetime`), `id_subCat` FROM `depenses`" +
                " WHERE `id_voyage`=(@id_voyage) AND `id_categorie`= 0 order by `m_datetime`";
            cmd.Connection = Connection.getInstance();
            cmd.CommandTimeout = 60;
            cmd.Parameters.AddWithValue("@id_voyage", voyage.Id_Voyage);
            cmd.Prepare();
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTimeOffset m_datetime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(reader.GetValue(6)));
                var tmp = new Depense(Convert.ToInt32(reader.GetValue(0)), Convert.ToInt32(reader.GetValue(1)),0, Convert.ToInt32(reader.GetValue(3)),
                    reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), m_datetime.UtcDateTime);
                voyage.AddDepense(tmp);
            }
            Connection.getInstance().Dispose();
        }

        public static void SelectVoyages(ObservableCollection<Voyage> listeDeVoyage)
        {
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "SELECT `id_voyage`,`name`, UNIX_TIMESTAMP(`date_depart`),UNIX_TIMESTAMP(`date_retour`)  FROM `voyages` where `id_utilisateur`=(@id_utilisateur)";
            cmd.Connection = Connection.getInstance();
            cmd.CommandTimeout = 60;
            cmd.Parameters.AddWithValue("@id_utilisateur", Utilisateur.Instance.Id_utilisateur);
            cmd.Prepare();
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTimeOffset date_depart = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(reader.GetValue(2)));
                DateTimeOffset date_retour = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt32(reader.GetValue(3)));
                var tmp = new Voyage(Convert.ToInt32(reader.GetValue(0)), reader.GetValue(1).ToString(), date_depart.UtcDateTime, date_retour.UtcDateTime );
                listeDeVoyage.Add(tmp);
            }
            Connection.getInstance().Dispose();
        }

        public static void Connection_Utilisateur(Utilisateur utilisateur)
        {
            Utilisateur tmp=null;
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.CommandText = "SELECT COUNT(`id_utilisateur`)as nombre,`id_utilisateur`, `login`, `password` FROM utilisateurs where `login`=(@login) and `password`=(@password)";
            cmd.Connection = Connection.getInstance();
            cmd.CommandTimeout = 60;
            cmd.Parameters.AddWithValue("@login", utilisateur.Login);
            cmd.Parameters.AddWithValue("@password", utilisateur.Password);
            cmd.Prepare();
            MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                if(Convert.ToInt32(reader.GetValue(0))== 1  && utilisateur.Password== reader.GetValue(3).ToString())
                {
                    //Connection.getInstance().Dispose();
                    tmp =new Utilisateur((int)reader.GetValue(1), reader.GetValue(2).ToString(), reader.GetValue(3).ToString());
                    break;
                }
            }
            Connection.getInstance().Dispose();
            if(tmp!=null) Utilisateur.Instance.hydrate(tmp);
            // call dispose before hydrating because there must be only a connection at the time
        }
        public static void HydrateCategorie()
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
        //insert
        public static void InsertDepense(Depense depense)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "insert into depenses (`m_datetime`, `id_voyage`, `id_categorie`, `id_subCat`, `prix`, `nom`, `commentaire`)" +
                    " VALUES(NOW(),@id_voyage,@id_categorie,LAST_INSERT_ID(),@prix,@nom,@commentaire)";
                commande.Parameters.AddWithValue("@id_voyage", 1);
                commande.Parameters.AddWithValue("@id_categorie", depense.findCategorie());
                commande.Parameters.AddWithValue("@prix", depense.Prix);
                commande.Parameters.AddWithValue("@nom", depense.Nom);
                commande.Parameters.AddWithValue("@commentaire", depense.Commentaire);
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
        public static void InsertTransport(Transport transport)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "INSERT INTO `transports`(`id_categorieTransport`, `depart`, `destination`)" +
                    "VALUES (@id_categorieTransport,@depart,@destination)";
                commande.Parameters.AddWithValue("@id_categorieTransport", 1);
                commande.Parameters.AddWithValue("@depart",transport.Depart);
                commande.Parameters.AddWithValue("@destination", transport.Destination);
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
        public static void InsertNourriture(Nourriture nourriture)
        {
            MySql.Data.MySqlClient.MySqlCommand commande = new MySql.Data.MySqlClient.MySqlCommand();
            try
            {
                commande.Connection = Connection.getInstance();
                commande.CommandText =
                    "INSERT INTO `nourritures`(`id_categorieNourriture`)" +
                    "VALUES (@id_categorieNourriture)";
                commande.Parameters.AddWithValue("@id_categorieNourriture", 1);
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
