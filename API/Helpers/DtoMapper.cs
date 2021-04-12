using API.Dtos;
using Core.Entities;

namespace API.Helpers
{
    public static class DtoMapper
    {
        public static AccountDto MapAccountDto(this Account account)
        {
            return new AccountDto
            {
                accountNumber = account.accountNumber,
                currencyCode = account.currencyCode,
                balance = account.balance
            };
        }

        public static TransactionDto MapTransactionDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                senderAccountNumber = transaction.senderAccountNumber,
                receiverAccountNumber = transaction.receiverAccountNumber,
                amount = transaction.amount
            };
        }
        
    }
}