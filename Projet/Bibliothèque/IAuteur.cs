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
        string nomAutheur { get; set; }
        string prenomAutheur { get; set; }
    }


    public class Auteur : IAuteur
    {
        public int Id { get; set; }
        public string nomAutheur { get; set; }
        public string prenomAutheur { get; set; }
    }
}
