using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Platinum : Account
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="name">
        /// Name
        /// </param>
        /// <param name="surname">
        /// Surname
        /// </param>
        public Platinum(string name, string surname) : base(name, surname)
        {
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="amount">
        /// Amount
        /// </param>
        /// <param name="name">
        /// Name
        /// </param>
        /// <param name="surname">
        /// Surname
        /// </param>
        public Platinum(int amount, string name, string surname) : base(amount, name, surname)
        {
        }

        /// <summary>
        /// Return bonus
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// Bonus
        /// </returns>
        protected override int SetBonus(int money)
        {
            return Amount / 1000 * 300;
        }
    }
}
