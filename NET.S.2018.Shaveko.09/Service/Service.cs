using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    using Repository;
    using Account;
    using AccountHolder;
    using GeneratorNumbers;

    /// <summary>
    /// Service
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Service()
        {
            Repository = new Repository();
        }

        /// <summary>
        /// Property of repository
        /// </summary>
        public Repository Repository { get; }

        /// <summary>
        /// Open account
        /// </summary>
        /// <param name="account">
        /// Account
        /// </param>
        public void Open(Account account)
        {
            Repository.Insert(account);
        }

        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <param name="money">
        /// Money
        /// </param>
        public void Deposit(string id, decimal money)
        {
            Account tmp = Repository.Select(id);
            tmp.Deposit(money);
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <param name="money">
        /// Money
        /// </param>
        public void Withdraw(string id, decimal money)
        {
            Account tmp = Repository.Select(id);
            tmp.Deposit(money);
        }
    }
}
