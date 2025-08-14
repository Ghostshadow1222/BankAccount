using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;

namespace BankAccountTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void Deposit_PositiveAmount_UpdatesBalance()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };

            // Act
            var result = account.Deposit(100m);

            // Assert
            Assert.AreEqual(100m, result); // Method returns updated balance value
            Assert.AreEqual(100m, account.Balance); // Actual balance is updated
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(-50m);
        }

        [TestMethod]
        public void Withdraw_ValidAmount_UpdatesBalance()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(200m);

            // Act
            var result = account.Withdraw(50m);

            // Assert
            Assert.AreEqual(150m, result);
            Assert.AreEqual(150m, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_NegativeAmount_ThrowsException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(100m);
            account.Withdraw(-10m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_AmountGreaterThanBalance_ThrowsException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(100m);
            account.Withdraw(150m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Withdraw_ZeroAmount_ThrowsException()
        {
            // Arrange
            var account = new Account { AccountNumber = "1234-ABCDE" };
            account.Deposit(100m);
            account.Withdraw(0m);
        }

        [TestMethod]
        public void AccountNumber_ValidFormat_DoesNotThrow()
        {
            // Arrange & Act
            var account = new Account { AccountNumber = "1234-ABCDE" };
            // Assert
            Assert.AreEqual("1234-ABCDE", account.AccountNumber);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("123-ABCDE")]
        [DataRow("12345-ABCDE")]
        [DataRow("1234-ABCDEF")]
        [DataRow("1234-abc1e")]
        [DataRow("abcd-ABCDE")]
        [DataRow("1234-abcde1")]
        [DataRow("1234ABCDE")]
        public void AccountNumber_InvalidFormat_ThrowsArgumentException(string invalidAccountNumber)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Account { AccountNumber = invalidAccountNumber });
        }
    }
}
