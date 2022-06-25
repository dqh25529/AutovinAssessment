using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessments
{
    public class InvestmentAccount : Account
    {
        private string _investmentType = string.Empty;

        public string InvestmentType
        {
            get { return _investmentType; }
            set { _investmentType = value; }
        }

        public InvestmentAccount(string owner, string type, string investmentType) :
            base(owner, type)
        {
            InvestmentType = investmentType;
        }
    }

    public class IndividualInvestmentAccout : InvestmentAccount
    {
        public IndividualInvestmentAccout(string owner, string type, string investmentType) : base(owner, type, investmentType)
        {
        }

        public override decimal Withdraw(decimal amount)
        {
            decimal allowAmount = amount;
            if (amount >= CommonValues.IndividualLimit)
                allowAmount = CommonValues.IndividualLimit;

            return base.Withdraw(allowAmount);
        }
    }

    public class CorporateInvestmentAccout : InvestmentAccount
    {
        public CorporateInvestmentAccout(string owner, string type, string investmentType) : base(owner, type, investmentType)
        {
        }
    }
}
