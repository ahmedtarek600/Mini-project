
namespace SimpleBank;

public class SavingsAccount : Account
{





    public decimal InterestRate { get; }   

    public SavingsAccount(string accountNumber , string clientName , decimal startBalance , decimal interestRate )

        : base(accountNumber, clientName, startBalance)
    {

        InterestRate = interestRate;

    }

    


    public override string GetDetails()
    {


        string line1 = $"[Savings] Account: {AccountNumber} | Client: {ClientName}";
        string line2 = FormattableString.Invariant($" Balance: ${Balance:F2} | Interest: {InterestRate}%");
        return line1 + Environment.NewLine + line2;


    }
}
