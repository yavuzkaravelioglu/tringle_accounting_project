using System;

namespace API.Dtos
{
    public class AccountDto
    {
        public int accountNumber { get; init; }
        public string currencyCode { get; set; }
        public decimal balance { get; set; }
    }
    
}