using BankingSystem.Enum;
using BankingSystem.Models;
using BankingSystem.Repositories;
using System.Net;

namespace Respositories.UnitTestCase
{
    [TestFixture]
    public class TransactionAcountUnitTest
    {
        private TransactionAcount transactionAcount;
        [SetUp]
        public void SetUp()
        {
            transactionAcount = new TransactionAcount();
        }

        [Test]
        public void UserShouldCreateAccount()
        {
            // Arrange
            var account = new Account()
            {
                ID = 1,
                Name = "Amit",
                Amount = 0,
                UserId = 1
            };

            // Act
            var result = transactionAcount.AddAccount(account);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(HttpStatusCode.Created));
        }

        [TestCase(1)]
        public void UserShouldDeleteAccount(int id)
        {
            // Act
            var result = transactionAcount.RemoveAccount(id);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(HttpStatusCode.OK));
        }

        [TestCase(1)]
        public void UserShouldDeleteAccountNotFound(int id)
        {
            // Act
            var result = transactionAcount.RemoveAccount(id);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void UserShouldDoTransactionCredit()
        {
            // Arrange
            var transaction = new Transaction() { AccountId = 1, TransactDate = new DateTime(2010, 1, 18), TransactionAmount = 200, TransactionType = TransactionType.Credit };
            // Act
            var result = transactionAcount.TransactionCreditAndWithdraw(transaction);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Sucessfully Money Credited"));
        }

        [Test]
        public void UserShouldDoTransactionCreditNotMoreThen10000dollar()
        {
            // Arrange
            var transaction = new Transaction() { AccountId = 1, TransactDate = new DateTime(2010, 1, 18), TransactionAmount = 10001, TransactionType = TransactionType.Credit };

            // Act
            var result = transactionAcount.TransactionCreditAndWithdraw(transaction);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Credit Amount is not more than 10000$ limit"));
        }

        [Test]
        public void UserShouldDoTransactionWithDrawSuccessful()
        {
            // Arrange
            var transaction = new Transaction() { AccountId = 1, TransactDate = new DateTime(2010, 1, 18), TransactionAmount = 200, TransactionType = TransactionType.Withdraw };

            // Act
            var result = transactionAcount.TransactionCreditAndWithdraw(transaction);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Sucessfully Money Debited"));
        }

        [Test]
        public void UserShouldDoTransactionWithDrawNotSuccessful()
        {
            // Arrange
            var transaction = new Transaction() { AccountId = 1, TransactDate = new DateTime(2010, 1, 18), TransactionAmount = 1801, TransactionType = TransactionType.Withdraw };

            // Act
            var result = transactionAcount.TransactionCreditAndWithdraw(transaction);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Account balance not be less than 100$ and withdraw amount not more than 90 %"));
        }

        [Test]
        public void UserShouldDoTransactionAccountNotFound()
        {
            // Arrange
            var transaction = new Transaction() { AccountId = 2, TransactDate = new DateTime(2010, 1, 18), TransactionAmount = 1801, TransactionType = TransactionType.Withdraw };

            // Act
            var result = transactionAcount.TransactionCreditAndWithdraw(transaction);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo("Account is Not found"));
        }
    }
}