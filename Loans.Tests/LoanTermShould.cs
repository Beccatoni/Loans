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
    }
}