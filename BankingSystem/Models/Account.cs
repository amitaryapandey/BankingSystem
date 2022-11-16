using BankingSystem.Enum;

namespace BankingSystem.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
    }
}
