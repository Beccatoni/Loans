using Loans.Domain.Applications;

namespace Loans.Tests;

public class LoanRepaymentCalculatorShould
{
    [Test]
    [TestCase(200_000, 6.5, 30, 1264.14)]
    [TestCase(200_000, 10, 30, 1755.14)]
    [TestCase(500_000, 10, 30, 4387.86)]
    public void CalculateCorrectMonthlyRepayment(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyRepayment)
    {
        var sut = new LoanRepaymentCalculator();
        var monthlyRepayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        
        Assert.That(monthlyRepayment, Is.EqualTo(expectedMonthlyRepayment));
    }
    
    [Test]
    [TestCase(200_000, 6.5, 30, ExpectedResult = 1264.14)]
    [TestCase(200_000, 10, 30, ExpectedResult = 1755.14)]
    [TestCase(500_000, 10, 30, ExpectedResult = 4387.86)]
    public decimal CalculateCorrectMonthlyRepayment_SimplifiedTestCase(decimal principal, decimal interestRate, int termInYears)
    {
        var sut = new LoanRepaymentCalculator();
        return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        
        // Assert.That(monthlyRepayment, Is.EqualTo(expectedMonthlyRepayment));
    }
    
    [Test]
    [TestCaseSource(typeof(MonthlyRepaymentTestData), "TestCases")]
    
    public void CalculateCorrectMonthlyRepayment_Centralized(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyRepayment)
    {
        var sut = new LoanRepaymentCalculator();
        var monthlyRepayment = sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        
        Assert.That(monthlyRepayment, Is.EqualTo(expectedMonthlyRepayment));
    }
    
    [Test]
    [TestCaseSource(typeof(MonthlyRepaymentTestDataWithReturn), "TestCases")]
    
    public decimal CalculateCorrectMonthlyRepayment_CentralizedWithReturn(decimal principal, decimal interestRate, int termInYears)
    {
        var sut = new LoanRepaymentCalculator();
        return sut.CalculateMonthlyRepayment(new LoanAmount("USD", principal), interestRate, new LoanTerm(termInYears));
        
        // Assert.That(monthlyRepayment, Is.EqualTo(expectedMonthlyRepayment));
    }


    
    
    
}