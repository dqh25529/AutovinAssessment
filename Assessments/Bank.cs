using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    public static class CommonValues
    {
        public static decimal IndividualLimit = 500.00m;
    }

    public class AccountTypes
    {
        public const string Checking = "Checking";
        public const string Investment = "Investment";
    }

    public class InvestmentTypes
    {
        public const string Individual = "Individual";
        public const string Corporate = "Corporate";
    }
    public class Bank
    {
        private string _name = string.Empty;
        private string _description = string.Empty;

        public string Name 
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<Account> Accounts { get; set; }

        public Bank(string name, string descripton)
        {
            _name = name;
            _description = descripton;
            Accounts = new List<Account>();
        }

        public string AddAccount(string owner, string accountType, string subType = "")
        {
            //This is acting like a factory
            if (String.IsNullOrEmpty(owner))
                return string.Empty;

            Account newAcct;
            switch (accountType)
            {
                case AccountTypes.Investment:
                    switch(subType)
                    {
                        case InvestmentTypes.Corporate:
                            newAcct = new CorporateInvestmentAccout(owner, accountType, subType);
                            break;
                        case InvestmentTypes.Individual:
                        default:
                            newAcct = new IndividualInvestmentAccout(owner, accountType, subType);
                            break;
                    }
                    break;
                case AccountTypes.Checking:
                default:
                    newAcct = new CheckingAccount(owner, accountType);
                    break;
            }
            Accounts.Add(newAcct);
            return newAcct.Id.ToString();
        }
        
        public List<Account> FindAccountsByOwner(string owner)
        {
            return Accounts.Where(a => a.Owner.Equals(owner, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Account? FindAccountById(string accountId)
        {
            return Accounts.Where(a => a.Id.ToString().Equals(accountId, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public decimal Deposit(string accountId, decimal amount)
        {
            Account? a = FindAccountById(accountId);
            if (a != null)
                return a.Deposit(amount);
            else
                return 0.0m;
        }

        public decimal Withdaw(string accountId, decimal amount)
        {
            Account? a = FindAccountById(accountId);
            if (a != null)
                return a.Withdraw(amount);
            else
                return 0.0m;
        }

        public decimal Transfer(string fromAccountId, string toAccountId, decimal amount)
        {
            Account? f = FindAccountById(fromAccountId);
            Account? t = FindAccountById(toAccountId);

            if(f != null && t != null)
            {
                decimal fAmount = f.Withdraw(amount);
                if(fAmount == amount)
                {
                    t.Deposit(amount);
                    return amount;
                }
            }

            return 0.0m;
        }
    }
}
