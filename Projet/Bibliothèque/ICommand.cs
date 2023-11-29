using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    internal interface ICommand
    {
        public interface ICommand
        {
            string Execute();
        }

        public class LoanBookCommand : ICommand
        {
            private int IdBook;

            public LoanBookCommand(int IdBook)
            {
                this.IdBook = IdBook;
            }

            public string Execute()
            {
                return Bdd.LoanBook(IdBook);
            }
        }

        public class CommandInvoker
        {
            private ICommand commande;

            public void SetCommand(ICommand command)
            {
                this.commande = command;
            }

            public void ExecuteCommand()
            {
                commande.Execute();
            }
        }
    }
}
