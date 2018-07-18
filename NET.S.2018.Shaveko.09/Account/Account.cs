using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    using AccountHolder;
    using GeneratorNumbers;

    /// <summary>
    /// Status of account
    /// </summary>
    public enum Status
    {
        Open,
        Freeze,
        Closed
    }

    /// <summary>
    /// Basic class of account
    /// </summary>
    public abstract class Account
    {
        private string id;
        private decimal _balance;
        private AccountHolder _holder;

        /// <summary>
        /// Constructor of account
        /// </summary>
        /// <param name="holder">
        /// Holder of account
        /// </param>
        /// <param name="balance">
        /// Balance
        /// </param>
        /// <param name="type">
        /// Type of account
        /// </param>
        protected Account(AccountHolder holder, decimal balance, IAccountGeneratorNumber type)
        {
            _holder = holder;
            _balance = balance;
            Bonus = CalculateBonus(balance);
            Status = Status.Open;
            id = type.GenerateAccountNumber();
        }

        /// <summary>
        /// Property of status
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// Property of id
        /// </summary>
        public string Id => id;

        /// <summary>
        /// Property of balance
        /// </summary>
        public decimal Balance
        {
            get => _balance;
            private set => _balance = IsValidBalance(value) ? value : throw new ArgumentException($"{nameof(_balance)} is full");
        }

        /// <summary>
        /// Property of bonus
        /// </summary>
        public int Bonus { get; private set; }

        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when money less then 0
        /// </exception>
        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException($"{nameof(money)} must be bigger than 0");
            }

            Balance += money;
            Bonus += CalculateBonus(money);
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <exception cref="ArgumentException">
        /// Throw when money less then 0
        /// </exception>
        public void WithDraw(decimal money)
        {
            if (money < 0)
            {
                throw new ArgumentException($"{nameof(money)} must be bigger than 0");
            }

            Balance -= money;
            Bonus -= CalculateBonus(money);
        }

        /// <summary>
        /// Abstract method of check balance
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// True or false
        /// </returns>
        protected abstract bool IsValidBalance(decimal money);

        /// <summary>
        /// Abstract method of calculate bonus
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// Bonus
        /// </returns>
        protected abstract int CalculateBonus(decimal money);
    }
}
