using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CreateTransactionDto
    {
        [Required]
        public int senderAccountNumber { get; set; }

        [Required]
        public int receiverAccountNumber { get; set; }

        [Required]
        public decimal amount { get; set; }
    }
    
}