using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    public class Account : ITransactions
    {
        private Guid _id;
        private string _owner = string.Empty;
        private decimal _balance;
        private string _type;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Account(string owner, string type)
        {
            _id = Guid.NewGuid();
            _owner = owner;
            _type = type;
        }
        public virtual decimal Deposit(decimal amount)
        {
            if (amount < 0.0m)
                return 0.0m;

            _balance += amount;
            return amount;
        }

        public virtual decimal Withdraw(decimal amount)
        {
            if (amount < 0.0m)
                return 0.0m;

            if (_balance > amount)
            {
                _balance -= amount;
                return amount;
            }
            else
                return 0.0m;
        }
    }
}
