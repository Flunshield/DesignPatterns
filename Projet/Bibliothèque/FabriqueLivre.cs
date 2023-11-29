using System;
using System.Collections.Generic;
using static Bibliothèque.BookIteratorr;
using static Bibliothèque.IIterator;

namespace Bibliothèque
{
    internal class FabriqueLivre
    {
        public interface IFabriqueLivre
        {
            string Creation();
        }

        public class Livre : IFabriqueLivre
        {
            public string Creation()
            {
                string titre = "";
                int categorieId = 0;
                int categorieNumber = 0;
                int auteurNumber = 0;
                int auteurId = 0;
                string date_parution = "";
                string empruntDate = "";
                int disponnibilite = 0;
                int prixlivre = 0;

                Console.WriteLine("Veuillez rentrez le nom de votre livre");
                titre = Console.ReadLine();
                Console.WriteLine("Veuillez sélectionner la catégorie de votre livre dans les catégories suivantes");

                List<Categorie> categorieList = Bdd.GetAllCategorie();
                IIterator<Categorie> categorieIterator = new Iterator<Categorie>(categorieList);

                int indexCategorie = 1;

                while (categorieIterator.HasNext())
                {
                    Categorie nextCategorie = categorieIterator.Next();
                    Console.WriteLine($"{indexCategorie}: {nextCategorie.nomCategorie}");
                    indexCategorie++;
                }

                if (int.TryParse(Console.ReadLine(), out categorieNumber))
                {
                    categorieId = categorieNumber;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un numéro de catégorie valide.");
                }

                Console.WriteLine("Veuillez renseignez l'id de l'auteur");

                List<Auteur> auteurList = Bdd.GetAllAuteurs();
                IIterator<Auteur> auteurIterator = new Iterator<Auteur>(auteurList);

                int indexAuteurList = 1;

                while (auteurIterator.HasNext())
                {
                    Auteur nextAuteur = auteurIterator.Next();
                    Console.WriteLine($"{indexAuteurList}: {nextAuteur.nomAuteur} {nextAuteur.prenomAuteur}");
                    indexAuteurList++;
                }

                if (int.TryParse(Console.ReadLine(), out auteurNumber))
                {
                    auteurId = auteurNumber;
                }
                else
                {
                    Console.WriteLine("Veuillez entrer un numéro d'auteur valide.");
                }

                Console.WriteLine("Veuillez renseignez la date de parution");
                date_parution = Console.ReadLine();

                Console.WriteLine("Veuillez renseigner le prix du livre");
                if (int.TryParse(Console.ReadLine(), out prixlivre) && prixlivre > 0)
                {
                    IBook livre = new Book();
                    livre.titre = titre;
                    livre.categorie = categorieId;
                    livre.auteur = auteurId;
                    livre.dateParution = date_parution;
                    livre.empruntDate = empruntDate;
                    livre.disponnibilite = disponnibilite;
                    livre.prixLivre = prixlivre;

                    Bdd.AddBooksToBdd(livre.titre, livre.categorie, livre.auteur, livre.dateParution, livre.empruntDate, livre.disponnibilite, livre.prixLivre);
                    return "";
                }
                else
                {
                    Console.WriteLine("Veuillez renseigner un nombre supérieur à 0");
                    return "";
                }
            }
        }

        public class Categories : IFabriqueLivre
        {
            public string Creation()
            {
                string nom = "";

                Console.WriteLine("Veuillez rentrer le nom de la catégorie que vous voulez ajouter");
                nom = Console.ReadLine();

                ICategorie categorie = new Categorie();
                categorie.nomCategorie = nom;

                Bdd.AddCategorieToBdd(categorie.nomCategorie);
                return "";
            }
        }

        public class Auteurs: IFabriqueLivre
        {
            public string Creation()
            {

                string nom = "";
                string prenom = "";

                Console.WriteLine("Veuillez rentrer le nom de l'auteur que vous voulez ajouter");
                nom = Console.ReadLine();

                Console.WriteLine("Veuillez rentrer le prénom de l'auteur que vous voulez ajouter");
                prenom = Console.ReadLine();

                IAuteur auteur = new Auteur();
                auteur.nomAuteur = nom;
                auteur.prenomAuteur = prenom;

                Bdd.AddAuteurToBdd(auteur.nomAuteur, auteur.prenomAuteur);
                return "";
            }
        }
    }
}
