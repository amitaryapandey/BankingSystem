using BankingSystem.Enum;

namespace BankingSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public int TransactionAmount { get; set; }
        public int AccountId { get; set; }
    }
}
