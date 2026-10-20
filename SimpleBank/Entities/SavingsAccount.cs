namespace SimpleBank.Entities;

public class SavingsAccount : Account
{
    public decimal InterestRate { get; }   

    public SavingsAccount(string accountNumber , string clientName , decimal startBalance , decimal interestRate )
        : base(accountNumber, clientName, startBalance)
    {
        InterestRate = interestRate;
    }


    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Error Transaction, Amount Must Be Greater Than 0");
            return false;
        }
        if (Balance < amount)
        {
            Console.WriteLine($"Not Enough Balance {amount}");
            return false;
        }
        Balance -= amount;
        Console.WriteLine($"Transaction Successful, Your Balance is: {Balance}");
        return true;
    }


    public override string GetDetails()
    {
        string line1 = $"[Savings] Account: {AccountNumber} | Client: {ClientName}";
        string line2 = FormattableString.Invariant($" Balance: ${Balance:F2} | Interest: {InterestRate}%");
        return line1 + Environment.NewLine + line2;
    }
}
