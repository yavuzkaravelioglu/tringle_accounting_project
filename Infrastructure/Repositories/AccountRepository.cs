using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> accounts = new List<Account>();

        // GET method
        public IEnumerable<Account> GetAccounts()
        {
            return accounts;
        }

        public Account GetAccountById(int id)
        {
            return accounts.Where(account => account.accountNumber == id).SingleOrDefault();
        }

        public bool IsAccountNumberUnique(int id)
        {
            var account = this.GetAccountById(id);
            if (account == null)
                return true;
            return false;
        }

        // POST method
        public void CreateAccount(Account account)
        {
            accounts.Add(account);
        }

        // Updates the Account 
        public void UpdateAccount(Account newAccount)
        {
            var index = accounts.FindIndex(account => account.accountNumber == newAccount.accountNumber);
            accounts[index] = newAccount;
        }

        
    }

}