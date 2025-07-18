using Loans.Domain.Applications;

namespace Loans.Tests;

[ProductComparison]
public class ProductComparerShould
{
    private List<LoanProduct> products;
    private ProductComparer sut;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // simulate long setup init time for this list of products
        // We assume that any tests will not modify this list
        // as this will potentially break other tests (i.e., break test isolation)
        products = new List<LoanProduct>
        {
            new LoanProduct(1, "a", 1),
            new LoanProduct(2, "b", 2),
            new LoanProduct(3, "c", 3)
        };
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // Run after the last test in this test class (fixture) executes
        // e.g., disposing of share expensive setup performed in OneTimeSetup
        // products.Dispose(); e.g., if products implemented IDisposable
        
    }
    [SetUp]
    public void Setup()
    {
        sut = new ProductComparer(new LoanAmount("USD", 200_000m), products);
    }

    [TearDown]
    public void TearDown()
    {
        // Runs after each test executes
        // sut.Dispose()
    }
    
    [Test]
    [Category("Product Comparison")]
    public void ReturnCorrectNumberOfComparisons()
    {
        List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));
        Assert.That(comparisons, Has.Exactly(3).Items);
    }
    
    [Test]
    public void NotReturnDuplicateComparisons()
    {
        List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));
        Assert.That(comparisons, Is.Unique);
        
    }
    
    [Test]
    public void ReturnComparisonForFirstProduct()
    {
        List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));
        
        // Need to also know the expected monthly repayment
        var expectedProduct = new MonthlyRepaymentComparison("a", 1, 643.28m);
        
        Assert.That(comparisons, Does.Contain(expectedProduct));
    }
    
    [Test]
    public void ReturnComparisonForFirstProduct_WithPartialKnownExpectedValues()
    {
        List<MonthlyRepaymentComparison> comparisons = sut.CompareMonthlyRepayments(new LoanTerm(30));
        
        // Don't care about the expected monthly repayment, only that the product is there 
        // Assert.That(comparisons, Has.Exactly(1)
        //                                       .Property("ProductName").EqualTo("a")
        //                                       .And
        //                                       .Property("InterestRate").EqualTo(1)
        //                                       .And
        //                                       .Property("MonthlyRepayment").GreaterThan(0));
        //   
        Assert.That(comparisons, Has.Exactly(1)
            .Matches<MonthlyRepaymentComparison>(
                item => item.ProductName == "a" &&
                                                 item.InterestRate == 1 &&
                                                 item.MonthlyRepayment > 0));
    }
    
}