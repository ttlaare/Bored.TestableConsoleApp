using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleApp.Tests
{
    // check out https://app.pluralsight.com/library/courses/nunit-3-dotnet-testing-introduction/table-of-contents for info on Nunit tests.
    public class OrderShould
    {

        [Test]
        [TestCaseSource(typeof(OrderShouldTestCases), "TestCases")]
        public void CalculateTotalPriceCorrectly(List<string> consoleInput, List<string> expectedConsoleOutput, double expectedTotalPrice)
        {
            var console = new ConsoleWrapper();
            console.LinesToRead = consoleInput;

            var sut = new Order(console); //sut = System under test.
            sut.PlaceFoodOrder();
            sut.PlaceDrinkOrder();
            var totalPrice = sut.CalculateTotalPrice();

            totalPrice.Should().BeApproximately(expectedTotalPrice, 0.004);
            console.WrittenLines.Count.Should().Be(expectedConsoleOutput.Count + 1);
            for (int i = 0; i < expectedConsoleOutput.Count; i++)
            {
                console.WrittenLines[i].Should().Be(expectedConsoleOutput[i]);
            }
        }
    }
}