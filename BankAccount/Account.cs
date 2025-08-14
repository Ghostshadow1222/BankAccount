using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents an individual bank account
    /// </summary>
    public class Account
    {
        private string _accountNumber;
        /// <summary>
        /// AccountNumbers must start with 4 diggits followed by a dash and then 5 characters (A - Z) not case sensitive
        /// </summary>
        public required string AccountNumber
        {
            get => _accountNumber;
            init
            {
                if (!IsValidAccountNumber(value))
                    throw new ArgumentException("Invalid account number format.", nameof(AccountNumber));
                _accountNumber = value;
            }
        }

        private static bool IsValidAccountNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            // 4 digits, dash, 5 letters (A-Z, case insensitive)
            return System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{4}-[A-Za-z]{5}$");
        }

        /// <summary>
        /// The current balance of the account
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Deposits money into the account then returns the new balance
        /// </summary>
        /// <param name="amount">The amount to deposit. Must be a positive value.</param>
        /// <returns>The updated account balance after the deposit</returns>
        public decimal Deposit (decimal amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Withdraws money from the account
        /// </summary>
        /// <param name="amount">The amount to withdraw. Must be positive value.</param>
        /// <returns>The updated account balance after the withdrawal.</returns>
        public decimal Withdraw (decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Cannot withdraw a negative amount or more than the current balance.");
            }

            Balance -= amount;
            return Balance;
        }


    }
}
