
using SimpleBank;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
namespace system_bank
{
    internal class displayAll
    {
       public static void ShowAllAccount(List<Account> accounts)
        {
            Console.WriteLine("----Accounts List----");
            foreach (Account acc in accounts)
            {
                Console.WriteLine(acc.GetDetails());
            }
        }
    }
}
