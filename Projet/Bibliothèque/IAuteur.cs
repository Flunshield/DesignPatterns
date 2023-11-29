using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface IAuteur
    {
        int Id { get; }
        string nomAuteur { get; set; }
        string prenomAuteur { get; set; }
    }


    public class Auteur : IAuteur
    {
        public int Id { get; set; }
        public string nomAuteur { get; set; }
        public string prenomAuteur { get; set; }
    }
}
