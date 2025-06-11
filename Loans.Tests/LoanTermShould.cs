

using Loans.Domain.Applications;

namespace Loans.Tests
{
    [TestFixture]
    public class LoanTermShould
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void ReturnLoanTermInMonths()
        {
            // System under test
            // Arrange
            var sut = new LoanTerm(1);
            
            // Act
            var numberOfMonths = sut.ToMonths();
            
            //Assert
            Assert.That(sut.ToMonths(), Is.EqualTo(12));
            
            
        }

        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(1);
            
            Assert.That(sut.Years, Is.EqualTo(1));
        }

        [Test]
        public void RespectValueEquality()
        {
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);
            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(1);
            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));
            
        }

        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));
        }

       
    }
}