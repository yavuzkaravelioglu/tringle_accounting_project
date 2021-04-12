using System;

namespace Core.Entities
{
    public class Account
    {
        public int accountNumber { get; init; }
        public string currencyCode { get; set; }
        public decimal balance { get; set; }

    }
}