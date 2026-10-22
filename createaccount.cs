
using SimpleBank;
using SimpleBank.Entities;
using System;
using System.Collections.Generic;
namespace system_bank
{
    internal class createaccount
    {

        public static void Create_Account(List<Account> accounts)
        {

            Console.WriteLine("Add New Account");
            Console.WriteLine("Choose Account Type");
            Console.WriteLine("1- Saving Acc");
            Console.WriteLine("2- Current Acc");
            Console.WriteLine("Enter 1 or 2");
            string? typeInput = Console.ReadLine();
            Console.WriteLine("Enter Acc Number (SA-100)");
            string accNo = Console.ReadLine()?.Trim() ?? "ACC-001";

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber.Equals(accNo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("This Acc Already Exist");
                    return;
                }
            }
            Console.WriteLine("Enter Client Name ");
            string name = Console.ReadLine()?.Trim() ?? "Client";
            Console.WriteLine("Enter Start Balance");
            decimal.TryParse(Console.ReadLine(), out decimal Balance);
            if (typeInput == "1")
            {
                Console.WriteLine("Enter InterSet %");
                decimal.TryParse(Console.ReadLine(), out decimal intersetRate);

                accounts.Add(new SavaingsAccount(accNo, name, Balance, intersetRate));
                Console.WriteLine("Added Succefully");

            }
            else if (typeInput == "2")
            {
                Console.WriteLine("Enter Extra Limit (1000)");
                decimal.TryParse(Console.ReadLine(), out decimal extraLimit);

                accounts.Add(new CurrentAccount(accNo, name, Balance, extraLimit));
                Console.WriteLine("Added Succefully");
            }
            else
            {
                Console.WriteLine("Invaild Type");
            }
        }

    }
}
