using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface IBook
    {
        string titre { get; set; }
        string auteur { get; set; }
        string categorie { get; set; }
        string emprunter { get; set; }
        string dateParution { get; set; }
        string empruntDate { get; set; }
        bool disponnibilité { get; set; }
        int prixLivre { get; set; }
    }
}
