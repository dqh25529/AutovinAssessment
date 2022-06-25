using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    internal interface ITransactions
    {
        decimal Deposit(decimal amount);
        decimal Withdraw(decimal amount);
        //decimal Transfer(string fromAcctId, string toAcctId, decimal amount);
    }
}
