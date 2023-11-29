﻿using Bibliothèque;
using System;
using static Bibliothèque.BookIteratorr;
using static Bibliothèque.IIterator;

class Program
{
    static void Main()
    {
        //Initialisation de la bdd avec le design patterne Singleton
        Bdd.Create();

        //Création de la console
        bool sorti = false;

        while (sorti == false)
        {

            Console.WriteLine("Bienvenue sur la Bibliothèque du tchékar");
            Console.WriteLine("Pour ajouter un livre ? Taper 1");
            Console.WriteLine("Pour ajouter une catégorie ? Taper 2");
            Console.WriteLine("Pour ajouter un auteur ? Taper 3");
            Console.WriteLine("Pour afficher les livres ? Taper 4");
            Console.WriteLine("Pour afficher les catégories ? Taper 5");
            Console.WriteLine("Pour afficher les auteurs ? Taper 6");
            Console.WriteLine("Pour sortir ? Taper 7");
            string chose = Console.ReadLine();

            switch (chose)
            {

                case "1":
                    FabriqueLivre.CreationLivre();
                    break;

                case "2":
                    FabriqueLivre.CreationCategorie();
                    break;

                case "3":
                    FabriqueLivre.CreationAuteur();
                    break;

                case "4":
                    List<Book> bookList = Bdd.GetAllBooks();
                    IIterator <Book> bookIterator = new Iterator<Book>(bookList);

                    Console.WriteLine("");
                    while (bookIterator.HasNext())
                    {
                        Book nextBook = bookIterator.Next();
                        Console.WriteLine($"Title: {nextBook.titre}, AuthorId: {nextBook.auteur}, categorieId: {nextBook.categorie}, date de parution: {nextBook.dateParution}, Emprunter ?: {nextBook.disponnibilité}");
                    }
                    Console.WriteLine("");
                    break;

                case "5":
                    List<Categorie> categorieList = Bdd.GetAllCategorie();
                    IIterator<Categorie> categorieIterator = new Iterator<Categorie>(categorieList);

                    Console.WriteLine("");
                    while (categorieIterator.HasNext())
                    {
                        Categorie nextCategorie = categorieIterator.Next();
                        Console.WriteLine($"nomCategorie: {nextCategorie.nomCategorie}");
                    }
                    Console.WriteLine("");
                    break;

                case "6":
                    List<Auteur> auteurList = Bdd.GetAllAuteurs();
                    IIterator<Auteur> auteursIterator = new Iterator<Auteur>(auteurList);

                    Console.WriteLine("");
                    while (auteursIterator.HasNext())
                    {
                        Auteur nextAuteur = auteursIterator.Next();
                        Console.WriteLine($"nomAuteur: {nextAuteur.nomAuteur}, prenomAuteur: {nextAuteur.prenomAuteur}");
                    }
                    Console.WriteLine("");
                    break;

                case "7":
                    sorti = true;
                    break;
                default:
                    break;
            }

        }
    }

}
