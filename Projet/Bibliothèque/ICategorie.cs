using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface ICategorie
    {
        int Id { get; }
        string nomCategorie { get; set; }
    }


    public class Categorie : ICategorie
    {
        public int Id { get; set; }
        public string nomCategorie { get; set; }
    }
}
