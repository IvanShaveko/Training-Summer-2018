using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Gold : Account
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
        public Gold(string name, string surname) : base(name, surname)
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
        public Gold(int amount, string name, string surname) : base(amount, name, surname)
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
            return 200 * Amount / 1000;
        }
    }
}
