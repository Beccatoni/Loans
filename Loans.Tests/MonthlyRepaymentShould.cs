using Loans.Domain.Applications;

namespace Loans.Tests;

public class MonthlyRepaymentShould
{
    [Test]
    [Category("Product Comparison")]
    public void RespectValueEquality()
    {
        var a = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
        var b = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
        
        Assert.That(a, Is.EqualTo(b));
        
    }

    [Test]
    public void RespectValueInequality()
    {
        var a = new MonthlyRepaymentComparison("a", 42.42m, 22.22m);
        var b = new MonthlyRepaymentComparison("a", 42.42m, 23.22m);

        Assert.That(a, Is.Not.EqualTo(b));
    }
}