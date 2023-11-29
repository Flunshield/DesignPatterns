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
        string nomCategory { get; set; }
    }


    public class Categorie : ICategorie
    {
        public int Id { get; set; }
        public string nomCategory { get; set; }
    }
}
