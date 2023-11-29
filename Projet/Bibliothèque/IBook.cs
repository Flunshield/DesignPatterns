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
        bool disponnibilité { get; set; }
        int prixLivre { get; set; }
    }
}
