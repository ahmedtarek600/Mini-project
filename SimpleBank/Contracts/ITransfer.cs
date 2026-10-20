using SimpleBank.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBank.Contracts
{
    public interface ITransfer
    {
        bool Transfer(Account toAccount, decimal amount);
    }
}
