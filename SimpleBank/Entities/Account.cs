using SimpleBank.Contracts;

namespace SimpleBank.Entities;


public abstract class Account : ITransfer
{
    public string AccountNumber { get; }
    public string ClientName    { get; }
    public decimal Balance { get; protected set; }


    protected Account(string accountNumber, string clientName, decimal startBalance)
    {
        AccountNumber = accountNumber;
        ClientName = clientName;
        Balance = startBalance;
    }

    public abstract bool Withdraw(decimal amount);
    public abstract string GetDetails();

   
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), " Deposit amount  greater than zero.");

             Balance += amount;
        Console.WriteLine($"Deposite Successfuly, Added: ${amount}, New Balance: {Balance}");
    }

   

    


    public bool Transfer(Account toAccount, decimal amount)
    {
        if (toAccount == null)
        {
            Console.WriteLine("Account Not Found");
            return false;
        }

        Console.WriteLine($"Amount Will Send From {ClientName} To {toAccount.ClientName}");

        if (Withdraw(amount))
        {
            toAccount.Deposit(amount);
            Console.WriteLine($"Transfer {amount} From {ClientName} To {toAccount.ClientName} was Successed");
            Console.WriteLine($"Your Balance is: {Balance}");
            return true;
        }

        Console.WriteLine($"Transfer Failed");
        return false;
    }
}
