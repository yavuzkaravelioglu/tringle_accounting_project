using System.Collections.Generic;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(int id);
        bool IsAccountNumberUnique(int id);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
    }
}