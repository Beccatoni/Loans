using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loans.Domain.Applications
{
    public class MonthlyRepaymentComparison : ValueObject
    {
        public string ProductName { get; }
        public decimal InterestRate { get; }
        public decimal MonthlyRepayment { get; }

        private MonthlyRepaymentComparison() { }

        public MonthlyRepaymentComparison(string productName, decimal interestRate, decimal monthlyRepayment)
        {
            ProductName = productName;
            InterestRate = interestRate;
            MonthlyRepayment = monthlyRepayment;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ProductName;
            yield return InterestRate;
            yield return MonthlyRepayment;
        }
    }
}
