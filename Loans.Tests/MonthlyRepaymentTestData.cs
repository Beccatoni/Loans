using System.Collections;

namespace Loans.Tests;

public class MonthlyRepaymentTestData
{
    public static IEnumerable TestCases
    {
        get
        {
            yield return new TestCaseData(200_000, 6.5, 30, 1264.14m);
            yield return new TestCaseData(200_000, 10, 30, 4387.86m);
        }
    }
}