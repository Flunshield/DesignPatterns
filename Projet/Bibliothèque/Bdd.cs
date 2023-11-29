using Bibliothèque;
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
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Auteur (id INT AUTO_INCREMENT PRIMARY KEY, nomAutheur VARCHAR(255), prenomAutheur VARCHAR(255));");

            // Création de la table Category
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Category (id INT AUTO_INCREMENT PRIMARY KEY, nomCategory VARCHAR(255));");

            // Création de la table Utilisateur
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Utilisateur (id INT AUTO_INCREMENT PRIMARY KEY, nomDeCompte VARCHAR(255), MotDePasse VARCHAR(255), pseudoUser VARCHAR(255));");

            // Création de la table Livre
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Livre (id INT AUTO_INCREMENT PRIMARY KEY, titre VARCHAR(255), auteurId INT, categorieId INT, emprunteurId INT, dateParution VARCHAR(255), empruntDate VARCHAR(255), disponibilite BOOLEAN, langue VARCHAR(255), prixlivre FLOAT);");

            // Création de la table Panier
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Panier (id INT AUTO_INCREMENT PRIMARY KEY, clientId INT, livreId INT, prixPanier FLOAT);");

            // Création de la table Historique
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Historique (id INT AUTO_INCREMENT PRIMARY KEY, titre VARCHAR(255), dateEmprunt VARCHAR(255), dateRetour VARCHAR(255), nomEmprunteur VARCHAR(255), prixTotal FLOAT);");
        }

        public static List<Book> GetAllBooks()
        {
            List<Book>  books = ExecuteQueryLivre("SELECT * FROM tp.livre;");
            return books;
        }

        public static List<Auteur> GetAllAuteurs()
        {
            List<Auteur> auteurs = ExecuteQueryAuteur("SELECT * FROM tp.auteur;");
            return auteurs;
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

        public static List<Book> ExecuteQueryLivre(string query)
        {
            List<Book> results = new List<Book>();

            MySqlConnectionSingleton dbConnection = MySqlConnectionSingleton.Instance;

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                connection.Close();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Book book = new Book
                        {
                            Id = reader.GetInt32("id"),
                            titre = reader.GetString("titre"),
                            auteur = reader.GetInt32("auteurId"),
                            categorie = reader.GetInt32("categorieId"),
                            emprunter = reader.GetInt32("emprunteurId"),
                            dateParution = reader.GetString("dateParution"),
                            empruntDate = reader.GetString("empruntDate"),
                            disponnibilité = reader.GetBoolean("disponibilite"),
                            prixLivre = reader.GetInt32("prixLivre"),
                        };

                        results.Add(book);
                    }
                }

                connection.Close();
            }

            return results;
        }

        public static List<Auteur> ExecuteQueryAuteur(string query)
        {
            List<Auteur> results = new List<Auteur>();

            MySqlConnectionSingleton dbConnection = MySqlConnectionSingleton.Instance;

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
                connection.Close();
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Auteur auteur = new Auteur
                        {
                            Id = reader.GetInt32("id"),
                            nomAutheur = reader.GetString("nomAutheur"),
                            prenomAutheur = reader.GetString("prenomAutheur")
                        };

                        results.Add(auteur);
                    }
                }

                connection.Close();
            }

            return results;
        }

    }

}