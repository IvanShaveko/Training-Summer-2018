using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorNumbers
{
    /// <summary>
    /// BaseGeneratorNumber
    /// </summary>
    public class BaseGenerator: IAccountGeneratorNumber
    {
        /// <summary>
        /// Generate numbers
        /// </summary>
        /// <returns>
        /// Number of account
        /// </returns>
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            int number = random.Next(10000, 99999);
            return "1" + number.ToString();
        }
    }

    /// <summary>
    /// SilverGeneratorNumber
    /// </summary>
    public class SilverGenerator: IAccountGeneratorNumber
    {
        /// <summary>
        /// Generate numbers
        /// </summary>
        /// <returns>
        /// Number of account
        /// </returns>
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            int number = random.Next(10000, 99999);
            return "2" + number.ToString();
        }
    }

    /// <summary>
    /// GoldGeneratorNumber
    /// </summary>
    public class GoldGenerator : IAccountGeneratorNumber
    {
        /// <summary>
        /// Generate numbers
        /// </summary>
        /// <returns>
        /// Number of account
        /// </returns>
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            int number = random.Next(10000, 99999);
            return "3" + number.ToString();
        }
    }

    /// <summary>
    /// PlatinumGeneratorNumber
    /// </summary>
    public class PlatinumGenerator : IAccountGeneratorNumber
    {
        public string GenerateAccountNumber()
        {
            Random random = new Random();
            int number = random.Next(10000, 99999);
            return "4" + number.ToString();
        }
    }
}
