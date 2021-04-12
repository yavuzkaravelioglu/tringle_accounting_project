using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Dtos
{
    public class CreateAccountDto
    {
        [Required(ErrorMessage = "Account Number is required.")]
        public int accountNumber { get; init; }

        [Required(ErrorMessage = "Currency Code is required.")]
        [RegularExpression(@"^(?i)(TRY|USD|EUR)$", ErrorMessage = "Currency Code must be 'TRY' or 'USD' or 'EUR'")]
        public string currencyCode { get; set; }

        [Required(ErrorMessage = "Balance of account must be declared")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$", ErrorMessage = "Balance must be decimal with 2 precision")]
        [Range(0.00, 9999999999999999.99)]
        public decimal balance { get; set; }
        
    }
}