using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorNumbers;

namespace Account
{
    /// <summary>
    /// Silver account
    /// </summary>
    public class SilverAccount : Account
    {
        private const int MAXBALANCE = 10000;

        /// <summary>
        /// Constructor of siver account
        /// </summary>
        /// <param name="holder">
        /// Holder
        /// </param>
        /// <param name="balance">
        /// Balance
        /// </param>
        public SilverAccount(AccountHolder.AccountHolder holder, decimal balance) : base(holder, balance, new SilverGenerator())
        {
        }

        /// <summary>
        /// Method of check balance
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// True or false
        /// </returns>
        protected override bool IsValidBalance(decimal money)
        {
            return MAXBALANCE - money != 0;
        }

        /// <summary>
        /// Method of calculate bonus
        /// </summary>
        /// <param name="money">
        /// Money
        /// </param>
        /// <returns>
        /// Bonus
        /// </returns>
        protected override int CalculateBonus(decimal money)
        {
            return (int)(100 + money / 1000);
        }
    }
}
