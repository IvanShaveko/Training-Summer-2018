using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Account;

    /// <summary>
    /// Repository
    /// </summary>
    public class Repository: IRepository
    {
        private readonly List<Account> _repository;

        /// <summary>
        /// Constructor of repository
        /// </summary>
        public Repository()
        {
            _repository = new List<Account>();
        }

        /// <summary>
        /// Property of repository
        /// </summary>
        public List<Account> List => _repository;

        /// <summary>
        /// Inserr account to repository
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account
        /// </param>
        public void Insert(Account bankAccount)
        {
            _repository.Add(bankAccount);
        }

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id">
        /// Id of account
        /// </param>
        /// <returns>
        /// Account
        /// </returns>
        public Account Select(string id)
        {
            int i;
            for (i = 0; i < _repository.Count; i++)
            {
                if (_repository[i].Id == id)
                {
                    return _repository[i];
                }
            }

            throw new ArgumentException($"{nameof(id)} is not exist");
        }

        /// <summary>
        /// Delete account
        /// </summary>
        /// <param name="bankAccount">
        /// Bank account
        /// </param>
        public void Delete(Account bankAccount)
        {
            if (!_repository.Contains(bankAccount))
            {
                throw new ArgumentException($"{nameof(bankAccount)} is not exist");
            }

            _repository.Remove(bankAccount);
        }
    }
}
