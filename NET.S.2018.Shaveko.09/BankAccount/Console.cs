using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Console
    {
        static void Main(string[] args)
        {
            Account account = new Gold(100, "Ivan", "Shaveko");
            while (true)
            {
                System.Console.WriteLine("0: Create account\n 1: Replenish\n 2: WithDraw\n 3: Show amount\n 4.Show bonus\n 5.Close\n 6.Exit");
                int operation = int.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
                int money;
                switch (operation)
                {
                    case 0:
                        break;
                    case 1:
                        money = int.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
                        account.Replenish(money);
                        break;
                    case 2:
                        money = int.Parse(System.Console.ReadLine() ?? throw new InvalidOperationException());
                        account.Withdraw(money);
                        break;
                    case 3:
                        System.Console.WriteLine(account.Amount);
                        break;
                    case 4:
                        System.Console.WriteLine(account.Bonus);
                        break;
                    case 5: 
                        account.Close();
                        break;
                    case 6: 
                        return;
                }
            }
        }
    }
}
