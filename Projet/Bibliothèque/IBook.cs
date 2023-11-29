using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface IBook
    {
        int Id { get; }
        string titre { get; set; }
        int auteur { get; set; }
        int categorie { get; set; }
        int emprunter { get; set; }
        string dateParution { get; set; }
        string empruntDate { get; set; }
        int disponnibilite { get; set; }
        int prixLivre { get; set; }
    }


    public class Book : IBook
    {
        public int Id { get; set; }
        public string titre { get; set; }
        public int auteur { get; set; }
        public int categorie { get; set; }
        public int emprunter { get; set; }
        public string dateParution { get; set; }
        public string empruntDate { get; set; }
        public int disponnibilite { get; set; }
        public int prixLivre { get; set; }
    }
}
