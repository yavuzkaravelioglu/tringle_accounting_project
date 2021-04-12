using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> transactions = new List<Transaction>();

        // GET method 
        public IEnumerable<Transaction> GetTransactions()
        {
            return transactions;
        }

        // POST method 
        public void CreateTransaction(Transaction transaction)
        {
            transactions.Add(transaction);
        }

    }
}