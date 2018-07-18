using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AccountHolder
{
    /// <summary>
    /// Account holder
    /// </summary>
    public sealed class AccountHolder
    {
        /// <summary>
        /// Constructoe of holder
        /// </summary>
        /// <param name="name">
        /// Name
        /// </param>
        /// <param name="surname">
        /// Surname
        /// </param>
        /// <param name="email">
        /// Email
        /// </param>
        public AccountHolder(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        /// <summary>
        /// Property of name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Property of surname
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Property of email
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Check email 
        /// </summary>
        /// <param name="value">
        /// The email whic must be check
        /// </param>
        /// <exception cref="ArgumentException">
        /// When email doesn't have needed format
        /// </exception>
        private void ValidateEmail(string value)
        {
            string tmp =
                @"([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
            Regex regex = new Regex(tmp);
            if (!regex.IsMatch(value))
            {
                throw new ArgumentException($"{nameof(value)} has wrong format");
            }
        }
    }
}
