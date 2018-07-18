using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    using Repository;
    using Service;
    using Account;
    using AccountHolder;

    class Program
    { 
        static void Main(string[] args)
        {
            Service service = new Service();
            Account tmp = new BaseAccount(new AccountHolder("Ivan", "Shaveko", "affa.@gmail.com"), 100);
            service.Open(tmp);
            System.Console.WriteLine(service.Repository.List[0].Balance);
            System.Console.ReadKey();
        }
    }
}
