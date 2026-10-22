namespace SimpleBank.Entities;

public class CurrentAccount : Account
{
    public decimal ExtraLimit { get; }   

    public CurrentAccount(string accountNumber, string clientName, decimal startBalance, decimal extraLimit)
        : base(accountNumber, clientName, startBalance)
    {
        ExtraLimit = extraLimit;
    }

   

    public override bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > Balance + ExtraLimit)
            return false;

        Balance -=  amount;
        return true;

    }

    



    public override string GetDetails()
    {
        string line1 = $"[Current] Account: {AccountNumber} | Client: {ClientName}";
        string line2 = FormattableString.Invariant($" Balance: ${Balance:F2} | Extra Limit: ${ExtraLimit:F2}");
        return line1 + Environment.NewLine + line2;
    }
}
