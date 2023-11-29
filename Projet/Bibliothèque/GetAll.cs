using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bibliothèque.BookIteratorr;
using static Bibliothèque.FabriqueLivre;
using static Bibliothèque.IIterator;

namespace Bibliothèque
{
    internal class GetAll
    {
        public interface IGetAll
        {
            string printGetAll();
        }

        public class Books
        {
            public string getAllBooks()
            {
                List<Book> bookList = Bdd.GetAllBooks();
                IIterator<Book> bookIterator = new Iterator<Book>(bookList);

                Console.WriteLine("");
                while (bookIterator.HasNext())
                {
                    Book nextBook = bookIterator.Next();
                    {
                        Console.WriteLine($"╔═════════════════════════════════════════╗");
                        Console.WriteLine($"║            {nextBook.titre}             ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║   Auteur: {nextBook.auteur}             ║");
                        Console.WriteLine($"║   Date de publication:                  ║");
                        Console.WriteLine($"║   {nextBook.dateParution}               ║");
                        Console.WriteLine($"║   Genre: {nextBook.categorie}           ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"║              ________________________   ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |                     |    ║");
                        Console.WriteLine($"║              |_____________________|    ║");
                        Console.WriteLine($"║                                         ║");
                        Console.WriteLine($"╚═════════════════════════════════════════╝");
                    }
                    Console.WriteLine($"Emprunter ?: {nextBook.disponnibilite}");
                }
                Console.WriteLine("");

                return "";
            }
        }

        public class Categories
        {
            public string getAllCategories()
            {
                List<Categorie> categorieList = Bdd.GetAllCategorie();
                IIterator<Categorie> categorieIterator = new Iterator<Categorie>(categorieList);

                Console.WriteLine("");
                while (categorieIterator.HasNext())
                {
                    Categorie nextCategorie = categorieIterator.Next();
                    Console.WriteLine($"nomCategorie: {nextCategorie.nomCategorie}");
                }
                Console.WriteLine("");

                return "";
            }
        }

        public class Auteurs
        {
            public string getAllAuteurs()
            {
                List<Auteur> auteurList = Bdd.GetAllAuteurs();
                IIterator<Auteur> auteursIterator = new Iterator<Auteur>(auteurList);

                Console.WriteLine("");
                while (auteursIterator.HasNext())
                {
                    Auteur nextAuteur = auteursIterator.Next();
                    Console.WriteLine($"nomAuteur: {nextAuteur.nomAuteur}, prenomAuteur: {nextAuteur.prenomAuteur}");
                }
                Console.WriteLine("");
                return "";
            }
        }

    }

}
