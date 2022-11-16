using BankingSystem.Models;
using System.Net;

namespace BankingSystem.Repositories
{
    public class TransactionAcount : ITransactionAccount
    {
        List<Account> accounts = new List<Account>() { new Account()
        {
            ID = 1,
            Name = "Amit",
            Amount = 2000,
            UserId = 1
        }};
        
        List<Transaction> transactions = new List<Transaction>();

        public HttpStatusCode AddAccount(Account account)
        {
            accounts.Add(account);
            return HttpStatusCode.Created;
        }

        public HttpStatusCode RemoveAccount(int id)
        {
            var result = accounts.FirstOrDefault(x => x.ID == id);
            if (result != null)
            {
                accounts.Remove(result);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotFound;
        }

        public string TransactionCreditAndWithdraw(Transaction transaction)
        {
            var result = accounts.FirstOrDefault(x => x.ID == transaction.AccountId);
            if (result != null)
            {
                
                switch (transaction.TransactionType)
                {
                    case Enum.TransactionType.Credit:
                        if (transaction.TransactionAmount < 10000)
                        {
                            result.Amount += transaction.TransactionAmount;
                            transactions.Add(transaction);
                            return "Sucessfully Money Credited";
                        }
                        return "Credit Amount is not more than 10000$ limit";
                    case Enum.TransactionType.Withdraw:
                        var percentage = (decimal)transaction.TransactionAmount / (decimal)result.Amount * 100;
                        if (percentage <= 90 && result.Amount - transaction.TransactionAmount >= 100)
                        {
                            result.Amount -= transaction.TransactionAmount;
                            transactions.Add(transaction);
                            return "Sucessfully Money Debited";
                        }
                        return "Account balance not be less than 100$ and withdraw amount not more than 90 %";
                    default:
                        break;
                }
            }
            return "Account is Not found";
        }
    }
}
