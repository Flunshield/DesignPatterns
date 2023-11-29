using Bibliothèque;
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
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    List<Book> bookList = Bdd.GetAllBooks();
                    IIterator <Book> bookIterator = new BookIterator(bookList);

                    Console.WriteLine("");
                    while (bookIterator.HasNext())
                    {
                        Book nextBook = bookIterator.Next();
                        Console.WriteLine($"Title: {nextBook.titre}, AuthorId: {nextBook.auteur}, categorieId: {nextBook.categorie}, date de parution: {nextBook.dateParution}, Emprunter ?: {nextBook.disponnibilité}");
                    }
                    Console.WriteLine("");
                    break;

                case "5":
                    break;

                case "6":
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
