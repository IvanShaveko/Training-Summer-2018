using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Account;

    /// <summary>
    /// Interface of service
    /// </summary>
    interface IService
    {
        /// <summary>
        /// Open account
        /// </summary>
        /// <param name="account">
        /// Account
        /// </param>
        void Open(Account account);

        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <param name="money">
        /// Money
        /// </param>
        void Deposit(string id, decimal money);

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <param name="money">
        /// Money
        /// </param>
        void Withdraw(string id, decimal money);
    }
}
