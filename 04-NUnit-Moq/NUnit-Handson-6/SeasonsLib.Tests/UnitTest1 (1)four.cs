using NUnit.Framework;
using SeasonsLib;
using System.Collections;

namespace SeasonsLib.Tests
{
    public class Tests
    {
        private SeasonTeller teller;

        [SetUp]
        public void Setup()
        {
            teller = new SeasonTeller();
        }

        public static IEnumerable SeasonTestData
        {
            get
            {
                yield return new TestCaseData("February", "Spring");
                yield return new TestCaseData("March", "Spring");

                yield return new TestCaseData("April", "Summer");
                yield return new TestCaseData("May", "Summer");
                yield return new TestCaseData("June", "Summer");

                yield return new TestCaseData("July", "Monsoon");
                yield return new TestCaseData("August", "Monsoon");
                yield return new TestCaseData("September", "Monsoon");

                yield return new TestCaseData("October", "Autumn");
                yield return new TestCaseData("November", "Autumn");

                yield return new TestCaseData("December", "Winter");
                yield return new TestCaseData("January", "Winter");

                yield return new TestCaseData("Hello", "Invalid Season");
            }
        }

        [TestCaseSource(nameof(SeasonTestData))]
        public void DisplaySeasonBy_ReturnsExpectedSeason(string month, string expected)
        {
            string result = teller.DisplaySeasonBy(month);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
