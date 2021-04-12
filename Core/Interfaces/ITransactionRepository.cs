using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ITransactionRepository
    {

        IEnumerable<Transaction> GetTransactions();

        void CreateTransaction(Transaction transaction);
        
    }
}