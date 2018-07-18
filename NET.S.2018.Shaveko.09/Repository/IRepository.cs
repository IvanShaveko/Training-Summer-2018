using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Account;

    /// <summary>
    /// Interface of repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Inserr account to repository
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account
        /// </param>
        void Insert(Account bankAccount);

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <returns>
        /// Account
        /// </returns>
        Account Select(string id);

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account
        /// </param>
        void Delete(Account bankAccount);
    }
}
