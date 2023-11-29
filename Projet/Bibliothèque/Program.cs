using Bibliothèque;
using System;
using static Bibliothèque.BookIteratorr;
using static Bibliothèque.ICommand;
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
            Console.WriteLine("Pour emprunter un livre ? Taper 7");
            Console.WriteLine("Pour sortir ? Taper 7");
            string chose = Console.ReadLine();

            switch (chose)
            {

                case "1":
                    FabriqueLivre.Livre livreInstance = new FabriqueLivre.Livre();
                    livreInstance.Creation();
                    break;

                case "2":
                    FabriqueLivre.Categories categorieInstance = new FabriqueLivre.Categories();
                    categorieInstance.Creation();
                    break;

                case "3":
                    FabriqueLivre.Auteurs auteurInstance = new FabriqueLivre.Auteurs();
                    auteurInstance.Creation();
                    break;

                case "4":
                    List<Book> bookList = Bdd.GetAllBooks();
                    IIterator <Book> bookIterator = new Iterator<Book>(bookList);

                    Console.WriteLine("");
                    while (bookIterator.HasNext())
                    {
                        Book nextBook = bookIterator.Next();
                        Console.WriteLine($"Title: {nextBook.titre}, AuthorId: {nextBook.auteur}, categorieId: {nextBook.categorie}, date de parution: {nextBook.dateParution}, Emprunter ?: {nextBook.disponnibilite}");
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

                    CommandInvoker invoker = new CommandInvoker();

                    Console.WriteLine("Quel livre souhaitez-vous emprunter ? Saisissez l'id");
                    string bookId = Console.ReadLine();
                    Bibliothèque.ICommand.ICommand addCommand = new LoanBookCommand(int.Parse(bookId));
                    invoker.SetCommand(addCommand);
                    invoker.ExecuteCommand();

                    break;
                default:
                    break;
            }

        }
    }

}
