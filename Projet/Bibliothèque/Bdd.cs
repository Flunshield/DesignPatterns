using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal class Bdd
    {
        public static void Create()
        {
            // Création de la base de données
            ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS tp;");

            // Utilisation de la base de données
            ExecuteNonQuery("USE tp;");

            // Création de la table Autheur
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Autheur (id INT PRIMARY KEY, nomAutheur VARCHAR(255), prenomAutheur VARCHAR(255));");

            // Création de la table Category
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Category (id INT PRIMARY KEY, nomCategory VARCHAR(255));");

            // Création de la table Utilisateur
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Utilisateur (id INT PRIMARY KEY, nomDeCompte VARCHAR(255), MotDePasse VARCHAR(255), pseudoUser VARCHAR(255));");

            // Création de la table Livre
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Livre (id INT PRIMARY KEY, titre VARCHAR(255), auteurId INT, categorieId INT, emprunteurId INT, dateParution VARCHAR(255), empruntDate VARCHAR(255), disponibilite BOOLEAN, langue VARCHAR(255), prixlivre FLOAT);");

            // Création de la table Panier
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Panier (id INT PRIMARY KEY, clientId INT, livreId INT, prixPanier FLOAT);");

            // Création de la table Historique
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Historique (id INT PRIMARY KEY, titre VARCHAR(255), dateEmprunt VARCHAR(255), dateRetour VARCHAR(255), nomEmprunteur VARCHAR(255), prixTotal FLOAT);");
        }

        private static void ExecuteNonQuery(string query)
        {
            MySqlConnectionSingleton dbConnection = MySqlConnectionSingleton.Instance;

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                connection.Close();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

    }

}
