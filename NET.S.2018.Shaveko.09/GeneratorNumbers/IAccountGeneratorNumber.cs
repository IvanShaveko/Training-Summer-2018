using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorNumbers
{
    /// <summary>
    /// Interface of generator number
    /// </summary>
    public interface IAccountGeneratorNumber
    {
        /// <summary>
        /// Method which generate number
        /// </summary>
        /// <returns></returns>
        string GenerateAccountNumber();
    }
}
