using BankingSystem.Models;
using System.Net;

namespace BankingSystem.Repositories
{
    public interface ITransactionAccount
    {
        HttpStatusCode AddAccount(Account account);
        string TransactionCreditAndWithdraw(Transaction transaction);

        HttpStatusCode RemoveAccount(int id);
    }
}
