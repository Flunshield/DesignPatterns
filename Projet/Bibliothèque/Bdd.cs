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

        public class Book : IBook
        {
            public int Id { get; set; }
            public string titre { get; set; }
            public int auteur { get; set; }
            public int categorie { get; set; }
            public int emprunter { get; set; }
            public string dateParution { get; set; }
            public string empruntDate { get; set; }
            public bool disponnibilité { get; set; }
            public int prixLivre { get; set; }
            // ... implémentez d'autres propriétés de l'interface IBook
        }


        public static void Create()
        {
            // Création de la base de données
            ExecuteNonQuery("CREATE DATABASE IF NOT EXISTS tp;");

            // Utilisation de la base de données
            ExecuteNonQuery("USE tp;");

            // Création de la table Autheur
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Autheur (id INT AUTO_INCREMENT PRIMARY KEY, nomAutheur VARCHAR(255), prenomAutheur VARCHAR(255));");

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

        public static List<IBook> GetAllBooks()
        {
            List<IBook>  books = ExecuteQuery("SELECT * FROM tp.livre;");
            return books;
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

        public static List<IBook> ExecuteQuery(string query)
        {
            List<IBook> results = new List<IBook>();

            MySqlConnectionSingleton dbConnection = MySqlConnectionSingleton.Instance;

            using (MySqlConnection connection = dbConnection.GetConnection())
            {
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
                            emprunter = reader.GetInt32("emprunterId"),
                            dateParution = reader.GetString("dateParution"),
                            empruntDate = reader.GetString("empruntDate"),
                            disponnibilité = reader.GetBoolean("disponnibilité"),
                            prixLivre = reader.GetInt32("prixLivre"),
                        };

                        results.Add(book);
                    }
                }

                connection.Close();
            }

            return results;
        }

    }

}
public class Book : IBook
{
    public int Id { get; set; }
    public string titre { get; set; }
    public string auteur { get; set; }
    public string categorie { get; set; }
    public string emprunter { get; set; }
    public string dateParution { get; set; }
    public string empruntDate { get; set; }
    public bool disponnibilité { get; set; }
    public int prixLivre { get; set; }
    // ... implémentez d'autres propriétés de l'interface IBook
}