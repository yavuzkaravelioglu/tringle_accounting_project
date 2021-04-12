using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accRepo;

        public AccountController(IAccountRepository accRepo)
        {
            this._accRepo = accRepo;
        }

        [HttpGet]
        public  IEnumerable<AccountDto> GetAccounts()
        {
            var accountList =  _accRepo.GetAccounts().Select(account => account.MapAccountDto());
            return accountList;   
        }

        [HttpPost]
        public ActionResult<AccountDto> CreateAccount(CreateAccountDto accountDto) //CreateAccountDto is input contract 
        {
            
            if ( _accRepo.IsAccountNumberUnique(accountDto.accountNumber) )
            {
                Account account = new()
                {
                    accountNumber = accountDto.accountNumber,
                    currencyCode = accountDto.currencyCode.ToUpper(),
                    balance = accountDto.balance
                };

                _accRepo.CreateAccount(account);
                return Ok();
            }

            return new ObjectResult("There is an existing Account with the same Account Number") {StatusCode = 400};

        }
        
    }
}