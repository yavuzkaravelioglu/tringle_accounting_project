using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TransactionController : ControllerBase
    {   
        private readonly IAccountRepository _accRepo;
        private readonly ITransactionRepository _transRepo;

        public TransactionController(IAccountRepository accRepo, ITransactionRepository transRepo)
        {
            this._accRepo = accRepo;
            this._transRepo = transRepo;
        }

        // GET METHOD
        [HttpGet]
        public IEnumerable<TransactionDto> GetAllTransactions()
        {
            var transactions = (_transRepo.GetTransactions()).Select( transaction => transaction.MapTransactionDto() );
            return transactions;
        }

        // POST METHOD
        [HttpPost]
        public ActionResult<TransactionDto> CreateTransaction(CreateTransactionDto transactionDto)
        {

            Transaction transaction = new()
            {
                senderAccountNumber = transactionDto.senderAccountNumber,
                receiverAccountNumber = transactionDto.receiverAccountNumber,
                amount = transactionDto.amount
            };

            var senderAccount = _accRepo.GetAccountById(transaction.senderAccountNumber);
            var receiverAccount = _accRepo.GetAccountById(transaction.receiverAccountNumber);

            var checkResult = CheckTransactionRestrictions(senderAccount, receiverAccount, transaction);
            if ( checkResult != "satisfy" )
                return new ObjectResult(checkResult) {StatusCode = 400};

            // All Conditions Satisfies
            _transRepo.CreateTransaction(transaction);
            UpdateAccountsBalance(senderAccount, receiverAccount, transaction.amount, this._accRepo);

            return Ok();

        }

        public static string CheckTransactionRestrictions(Account senderAccount, Account receiverAccount, Transaction transaction )
        {
            if ( senderAccount == null || receiverAccount == null )
            {
                return "Account not Exist!";
            }

            if ( senderAccount.currencyCode != receiverAccount.currencyCode )
            {
                return "Currency Code Mismatch! Account Must Have the Same Currency Code!";
            }

            if ( senderAccount.balance < transaction.amount )
            {
                return "Insufficient Balance! Sender Account has no avaliable fund!";
            }

            return "satisfy";

        }

        public static void UpdateAccountsBalance( Account senderAccount, Account receiverAccount, decimal amount, IAccountRepository accRepo)
        {
            senderAccount.balance -= amount; 
            receiverAccount.balance += amount;

            accRepo.UpdateAccount(senderAccount);
            accRepo.UpdateAccount(receiverAccount);
        }
        
    }
}