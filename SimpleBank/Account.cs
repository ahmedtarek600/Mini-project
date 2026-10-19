
namespace SimpleBank;


public abstract class Account
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

   
    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)


            throw new ArgumentOutOfRangeException(nameof(amount), " Deposit amount  greater than zero.");

             Balance += amount;




    }

   





    public virtual bool Withdraw(decimal amount)
    {

        if (amount <= 0     ||   amount > Balance)

            return false;


        Balance -= amount;

        return true;




    }

    
    public abstract string GetDetails();







}
