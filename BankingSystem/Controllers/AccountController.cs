using BankingSystem.Models;
using BankingSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITransactionAccount _transactionAccount;
        public AccountController(ITransactionAccount transactionAccount)
        {
            _transactionAccount = transactionAccount;
        }

        // POST api/<BankingSystemController>
        [Route("CreateAccount")]
        [HttpPost]
        public HttpStatusCode CreateAccount([FromBody] Account value)
        {
            return _transactionAccount.AddAccount(value);
        }

        // POST api/<BankingSystemController>
        [Route("TransactionCreaditAndWithdraw")]
        [HttpPost]
        public string TransactionCreaditAndWithdraw([FromBody] Transaction value)
        {
           return _transactionAccount.TransactionCreditAndWithdraw(value);
        }

        // DELETE api/<BankingSystemController>/5
        [HttpDelete("{id}")]
        public HttpStatusCode DeleteAccount(int id)
        {
            return _transactionAccount.RemoveAccount(id);
        }
    }
}
