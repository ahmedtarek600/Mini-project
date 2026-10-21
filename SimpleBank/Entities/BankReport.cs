
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBank
{
    public class BankReports
    {
        
        public void DisplayAllAccounts(List<Account> accounts)
        {
            Console.WriteLine("\n===== All Accounts =====");

            if (accounts == null || accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
                return;
            }

            foreach (Account account in accounts)
            {
                Console.WriteLine(account.GetDetails());
            }
        }

        
        public decimal GetTotalBalance(List<Account> accounts)
        {
            return accounts.Sum(account => account.Balance);
        }

        
        public int GetAccountsCount(List<Account> accounts)
        {
            return accounts.Count;
        }

        
        public decimal GetAverageBalance(List<Account> accounts)
        {
            if (accounts.Count == 0)
                return 0;

            return GetTotalBalance(accounts) / accounts.Count;
        }

        
        public void DisplaySummary(List<Account> accounts)
        {
            Console.WriteLine("\n===== Bank Summary =====");

            Console.WriteLine(
                $"Total Accounts: {GetAccountsCount(accounts)}");

            Console.WriteLine(
                $"Total Balance: {GetTotalBalance(accounts):F2}");

            Console.WriteLine(
                $"Average Balance: {GetAverageBalance(accounts):F2}");
        }
    }
}
