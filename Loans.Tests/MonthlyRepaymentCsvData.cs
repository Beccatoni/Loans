using System.Collections;

namespace Loans.Tests;

public class MonthlyRepaymentCsvData
{
    public static IEnumerable GetTestCases(string csvFileName)
    {
        var csvLines = File.ReadAllLines(csvFileName);

        var testCases = new List<TestCaseData>();

        foreach (var line in csvLines)
        {
            string[] values = line.Replace(" ", "").Split(',');

            decimal principal = decimal.Parse(values[0]);
            decimal interestRate = decimal.Parse(values[1]);
            int termInYears = int.Parse(values[2]);
            decimal expectedMonthlyRepayment = decimal.Parse(values[3]);
            
            testCases.Add(new TestCaseData(principal, interestRate, termInYears, expectedMonthlyRepayment));
        }

        return testCases;
    }
}