
using SimpleBank;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
namespace system_bank
{
    internal class findAccount
    {

        public static Account? accsearch(List<Account> accounts)
        {

            Console.WriteLine("Enter Acc No");
            string? num = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(num))
            {
                Console.WriteLine("Acc No Cannt be Empty");
                return null;
            }
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber.Equals(num, StringComparison.OrdinalIgnoreCase))
                    return accounts[i];
            }
            Console.WriteLine($"Account number {num} was not found.");
            return null;
        } 
    }
}
