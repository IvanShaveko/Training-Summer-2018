using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Account
    /// </summary>
    class Account
    {
        #region Fields
        /// <summary>
        /// Amount
        /// </summary>
        private int _amount;
        /// <summary>
        /// Status
        /// </summary>
        private bool _status;
        /// <summary>
        /// Bonus
        /// </summary>
        private int _bonus;
        /// <summary>
        /// Number
        /// </summary>
        private readonly int count = 0;

        #endregion

        #region Properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Suranme
        /// </summary>
        public string Surname { get; }
        /// <summary>
        /// Number
        /// </summary>
        public int Number { get; }
        /// <summary>
        /// Amount
        /// </summary>
        public int Amount => _amount;
        /// <summary>
        /// Bonus
        /// </summary>
        public int Bonus => _bonus;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="name">
        /// Name
        /// </param>
        /// <param name="surname">
        /// Surname
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when name or surname is null
        /// </exception>
        public Account(string name, string surname)
        {
            if (name == null || surname == null)
            {
                throw new ArgumentNullException($"{nameof(name)} or {nameof(surname)} can not be null");
            }

            _amount = 0;
            _status = true;
            Name = name;
            Surname = surname;
            Number = count++;
            _bonus = 0;
        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="name">
        /// Name
        /// </param>
        /// <param name="surname">
        /// Surname
        /// </param>
        /// <param name="amount">
        /// Amount
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Throw when name or surname is null
        /// </exception>
        public Account(int amount, string name, string surname)
        {
            if (name == null || surname == null)
            {
                throw new ArgumentNullException($"{nameof(name)} or {nameof(surname)} can not be null");
            }

            _amount = amount;
            _status = true;
            Name = name;
            Surname = surname;
            Number = count++;
            _bonus += SetBonus(amount);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Method to replenish money
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        public void Replenish(int money)
        {
            if (_status == false)
            {
                throw new ArgumentNullException($"{nameof(_status)} must be opened");
            }

            _amount += money;
            _bonus += SetBonus(money);
        }

        /// <summary>
        /// Method to withdraw money
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        public void Withdraw(int money)
        {
            if (_amount == 0)
            {
                throw new ArgumentException($"{nameof(_amount)} must be not 0");
            }

            if (_status == false)
            {
                throw new ArgumentNullException($"{nameof(_status)} must be opened");
            }

            _amount -= money;
            _bonus -= SetBonus(money);
        }

        /// <summary>
        /// Close account
        /// </summary>
        public void Close()
        {
            _status = false;
        }

        /// <summary>
        /// Open account
        /// </summary>
        public void Open()
        {
            _status = true;
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Set bonus
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// Bonus
        /// </returns>
        protected virtual int SetBonus(int money)
        {
            return  _amount/1000;
        }

        #endregion
    }
}
