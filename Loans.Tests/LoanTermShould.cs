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
        public void ReturnTermInMonths()
        {
            // sut = system under test
            var sut = new LoanTerm(1);

            //check the value
            Assert.That(sut.ToMonths(), Is.EqualTo(12), "Months should be 12 * number of years");
        }

        [Test]
        public void StoreYears()
        {
            var sut = new LoanTerm(3);

            Assert.That(sut.Years, Is.EqualTo(3));
        }

        [Test]
        public void RespectValueEquality()
        {
            //loanterm inherits from valuesobject base class = classes are reference types so usually 2 instances
            // would not be equal. See in valueobject that the equals methodhas been overriden.
            // If you comment this out (with GetHashCode method) the assert will fail as they are different references to the same object
            var a = new LoanTerm(1);
            var b = new LoanTerm(1);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new LoanTerm(1);
            var b = a;
            var c = new LoanTerm(2);

            // SaweAs() checks if that both variables point to the same object in 
            // memory - only concerned with references and not values
            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));

            // List<T> is a reference type
            var x = new List<string> { "Becca", "Edine" };
            var y = x;
            var z = new List<string> { "Becca", "Edine" };

            Assert.That(y, Is.SameAs(x));
            Assert.That(z, Is.Not.SameAs(x)); //SameAs() constraint is only concerned with comparing references, not values

        }

        [Test]
        public void Double()
        {
            double a = 1.0 / 3.0;

            //Assert.That(a, Is.EqualTo(0.33) => fails because exact answer is 0.33333333331d
            //Within() method allows us to specify to tolerance 
            Assert.That(a, Is.EqualTo(0.33).Within(0.004));

            //Can also specify a percentage tolerance with the percent Modifier
            Assert.That(a, Is.EqualTo(0.33).Within(10).Percent);
        }

        [Test]
        public void NotAllowZeroYears()
        {

        }
    }
}