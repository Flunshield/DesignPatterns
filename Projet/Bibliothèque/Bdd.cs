﻿using Bibliothèque;
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
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Auteur (id INT AUTO_INCREMENT PRIMARY KEY, nomAuteur VARCHAR(255), prenomAuteur VARCHAR(255));");

            // Création de la table Category
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Categorie (id INT AUTO_INCREMENT PRIMARY KEY, nomCategorie VARCHAR(255));");

            // Création de la table Utilisateur
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Utilisateur (id INT AUTO_INCREMENT PRIMARY KEY, nomDeCompte VARCHAR(255), MotDePasse VARCHAR(255), pseudoUser VARCHAR(255));");

            // Création de la table Livre
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Livre (id INT AUTO_INCREMENT PRIMARY KEY, titre VARCHAR(255), auteurId INT, categorieId INT, emprunteurId INT, dateParution VARCHAR(255), empruntDate VARCHAR(255), disponibilite INT, langue VARCHAR(255), prixlivre FLOAT);");

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
            List<Auteur> auteurs = ExecuteQueryAuteur("SELECT * FROM tp.Auteur;");
            return auteurs;
        }
        
        public static List<Categorie> GetAllCategorie()
        {
            List<Categorie> Categorie = ExecuteQueryCategorie("SELECT * FROM tp.Categorie;");
            return Categorie;
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
                            disponnibilite = reader.GetInt32("disponibilite"),
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
                            nomAuteur = reader.GetString("nomAuteur"),
                            prenomAuteur = reader.GetString("prenomAuteur")
                        };

                        results.Add(auteur);
                    }
                }

                connection.Close();
            }

            return results;
        }

        public static List<Categorie> ExecuteQueryCategorie(string query)
        {
            List<Categorie> results = new List<Categorie>();

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
                        Categorie categorie = new Categorie
                        {
                            Id = reader.GetInt32("id"),
                            nomCategorie = reader.GetString("nomCategorie"),
                        };

                        results.Add(categorie);
                    }
                }

                connection.Close();
            }

            return results;
        }

        public static void AddBooksToBdd(string titre, int categorieId, int auteurId, string date_parution, string empruntDate, int disponnibilite, float prixLivre)
        {
            try
            {
                string insertQuery = $"INSERT INTO Livre (titre, categorieId, auteurId, emprunteurId, dateParution, empruntDate, disponibilite, prixLivre) VALUES ('{titre}', '{categorieId}', '{auteurId}', '0', '{date_parution}', '{empruntDate}', '{disponnibilite}', '{prixLivre}')";
                ExecuteNonQuery(insertQuery);
                Console.WriteLine($"Le livre '{titre}' a bien été créé");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'ajout du livre : {ex.Message}");
            }
        }

        public static void AddCategorieToBdd(string name)
        {
            try
            {
                string insertQuery = $"INSERT INTO Categorie (nomCategorie) VALUES ('{name}')";
                ExecuteNonQuery(insertQuery);

                Console.WriteLine($"La catégorie '{name}' a bien été créé");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'ajout du livre : {ex.Message}");
            }
        }

        public static void AddAuteurToBdd(string name, string prenom)
        {
            try
            {
                string insertQuery = $"INSERT INTO Auteur (nomAuteur, prenomAuteur) VALUES ('{name}', '{prenom}')";
                ExecuteNonQuery(insertQuery);

                Console.WriteLine($"'{name}' '{prenom}' a bien été créé");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'ajout de l'auteur : {ex.Message}");
            }
        }

        public static void LoanBook(int id)
        {
            DateTime empruntDate = DateTime.Now;
            try
            {
                string checkBook = $"SELECT * FROM livre WHERE id = {id}";
                List<Book> book = ExecuteQueryLivre(checkBook);

                if (book[0].disponnibilite == 0) {
                    string insertQuery = $"UPDATE livre SET empruntDate = '{empruntDate}', disponibilite = '1' WHERE id = {id}";
                    ExecuteNonQuery(insertQuery);
                    Console.WriteLine($"Vous avez emprunter le livre {book[0].titre}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Le livre est déja emprunter");
                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite lors de l'emprunt du livre : {ex.Message}");
            }
        }
    }

}