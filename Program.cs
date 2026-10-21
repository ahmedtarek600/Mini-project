using System;
using System.Collections.Generic;
using SimpleBank.Entities;

namespace SimpleBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>()
            {
                new SavingsAccount("SA-101", "Ahmed Mahmoud", 5000m, 6.0m),
                new CurrentAccount("CA-202", "Mohamed tarek", 3000m, 2000m),
                new SavingsAccount("SA-103", "Hassan Naser", 4000m, 3.5m)
            };

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("          Bank System           ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Show All Accounts");
                Console.WriteLine("2. Deposit Money");
                Console.WriteLine("3. Withdraw Money");
                Console.WriteLine("4. Send Money");
                Console.WriteLine("5. Add New Account");
                Console.WriteLine("6. Total Bank Money");
                Console.WriteLine("0. Exit");
                Console.WriteLine("------------------------------");
                Console.Write("Enter Choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllAccounts(accounts);
                        break;

                    case "2":
                        HandleDeposite(accounts);
                        break;

                    case "3":
                        HandleWithdraw(accounts);
                        break;

                    case "4":
                        HandleTransfer(accounts);
                        break;

                    case "5":
                        HandleCreateAccount(accounts);
                        break;

                    case "6":
                        ShowTotalMony(accounts);
                        break;

                    case "0":
                        isRunning = false;
                        Console.WriteLine("\nThank you for using Bank System. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("\n[Error] Invalid Choice. Please try again.");
                        break;
                }

                // وضع Press Enter to continue في المكان الصحيح داخل حلقة التشغيل
                if (isRunning)
                {
                    Console.WriteLine("\nPress Enter To Continue...");
                    Console.ReadLine();
                }
            }
        }

        static void ShowAllAccounts(List<Account> accounts)
        {
            Console.WriteLine("\n---- Accounts List ----");
            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found in the system.");
                return;
            }

            foreach (Account acc in accounts)
            {
                Console.WriteLine(acc.GetDetails());
                Console.WriteLine("--------------------");
            }
        }

        static void HandleDeposite(List<Account> accounts)
        {
            Console.WriteLine("\n--- Deposit Money ---");
            Account? account = FindAccount(accounts);
            if (account == null) return;

            Console.Write("Enter deposit amount: ");
            // التحقق من أن المبلغ قيمة موجبة أكبر من الصفر
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                try
                {
                    account.Deposit(amount);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Error] {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("[Error] Invalid amount. Deposit must be greater than zero.");
            }
        }

        static void HandleWithdraw(List<Account> accounts)
        {
            Console.WriteLine("\n--- Withdraw Money ---");
            Account? account = FindAccount(accounts);
            if (account == null) return;

            Console.Write("Enter withdraw amount: ");
            // التحقق من أن المبلغ قيمة موجبة أكبر من الصفر
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("[Error] Invalid amount. Withdraw must be greater than zero.");
            }
        }

        static void HandleTransfer(List<Account> accounts)
        {
            Console.WriteLine("\n--- Send Money (Transfer) ---");

            Console.WriteLine("From Account (Sender):");
            Account? fromAccount = FindAccount(accounts);
            if (fromAccount == null) return;

            Console.WriteLine("\nTo Account (Receiver):");
            Account? toAccount = FindAccount(accounts);
            if (toAccount == null) return;

            if (fromAccount.AccountNumber.Equals(toAccount.AccountNumber, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("[Error] You cannot send money to the same account.");
                return;
            }

            Console.Write("Enter amount to send: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                fromAccount.Transfer(toAccount, amount);
            }
            else
            {
                Console.WriteLine("[Error] Invalid amount. Transfer amount must be greater than zero.");
            }
        }

        static void HandleCreateAccount(List<Account> accounts)
        {
            Console.WriteLine("\n--- Add New Account ---");
            Console.WriteLine("Choose Account Type:");
            Console.WriteLine("1- Savings Account");
            Console.WriteLine("2- Current Account");
            Console.Write("Enter 1 or 2: ");
            string? typeInput = Console.ReadLine();

            Console.Write("Enter Account Number (e.g., SA-100): ");
            string accNo = Console.ReadLine()?.Trim() ?? "ACC-001";

            // منع إنشاء حساب برقم مكرر
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber.Equals(accNo, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[Error] This Account Number already exists! Cannot create duplicate accounts.");
                    return;
                }
            }

            Console.Write("Enter Client Name: ");
            string name = Console.ReadLine()?.Trim() ?? "Client";

            Console.Write("Enter Start Balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal startBalance) || startBalance < 0)
            {
                Console.WriteLine("[Error] Invalid start balance. Setting balance to 0.");
                startBalance = 0;
            }

            if (typeInput == "1")
            {
                Console.Write("Enter Interest Rate %: ");
                decimal.TryParse(Console.ReadLine(), out decimal interestRate);

                accounts.Add(new SavingsAccount(accNo, name, startBalance, interestRate));
                Console.WriteLine("[Success] Savings Account added successfully.");
            }
            else if (typeInput == "2")
            {
                Console.Write("Enter Extra Limit (e.g., 1000): ");
                decimal.TryParse(Console.ReadLine(), out decimal extraLimit);

                accounts.Add(new CurrentAccount(accNo, name, startBalance, extraLimit));
                Console.WriteLine("[Success] Current Account added successfully.");
            }
            else
            {
                Console.WriteLine("[Error] Invalid Account Type selected.");
            }
        }

        static void ShowTotalMony(List<Account> accounts)
        {
            decimal total = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                total += accounts[i].Balance;
            }
            Console.WriteLine($"\n--- Bank Statistics ---");
            Console.WriteLine($"Total Bank Money: {total}");
            Console.WriteLine($"Active Accounts Count: {accounts.Count}");
        }

        static Account? FindAccount(List<Account> accounts)
        {
            Console.Write("Enter Account No: ");
            string? num = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(num))
            {
                Console.WriteLine("[Error] Account Number cannot be empty.");
                return null;
            }

            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountNumber.Equals(num, StringComparison.OrdinalIgnoreCase))
                    return accounts[i];
            }

            //  رسائل الأخطاء عند عدم وجود الحساب
            Console.WriteLine($"[Error] Account number '{num}' was not found in the system.");
            return null;
        }
    }
}
