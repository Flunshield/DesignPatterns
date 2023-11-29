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
            void Execute();
        }

        public class LoanBookCommand : ICommand
        {
            private int IdBook;

            public LoanBookCommand(int IdBook)
            {
                this.IdBook = IdBook;
            }

            public void Execute()
            {
                Bdd.LoanBook(IdBook);
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
