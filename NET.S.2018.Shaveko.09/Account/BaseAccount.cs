using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorNumbers;

namespace Account
{
    /// <summary>
    /// Base account
    /// </summary>
    public class BaseAccount : Account
    {
        private const int MAXBALANCE = 1000;

        /// <summary>
        /// Constructor of base account
        /// </summary>
        /// <param name="holder">
        /// Holder
        /// </param>
        /// <param name="balance">
        /// Balance
        /// </param>
        public BaseAccount(AccountHolder.AccountHolder holder, decimal balance) : base(holder, balance, new BaseGenerator())
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
            return (int) (100 + money / 10000);
        }
    }
}
