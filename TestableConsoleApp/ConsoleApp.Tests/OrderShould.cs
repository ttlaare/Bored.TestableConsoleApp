using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ConsoleApp.Helpers;
using ConsoleApp.OrderItems;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace ConsoleApp.Tests
{
    // check out https://app.pluralsight.com/library/courses/nunit-3-dotnet-testing-introduction/table-of-contents for info on Nunit tests.
    public class OrderShould
    {
        [Test]
        [UseApprovalSubdirectory("OrderShould.ApprovedFiles")]
        [UseReporter(typeof(DiffReporter))]
        [TestCase("1,1", 4.4, "Test1", TestName = "Test1")]
        [TestCase("1,2", 4.9, "Test2", TestName = "Test2")]
        [TestCase("2,1", 3.9, "Test3", TestName = "Test3")]
        [TestCase("2,2", 4.4, "Test4", TestName = "Test4")]
        public void CalculateTotalPriceCorrectly(string consoleInput, double expectedTotalPrice, string testName)
        {
            //Arrange
            var console = new ConsoleWrapper();
            var repository = Factory.BuildOrderItemRepository();
            console.LinesToRead = consoleInput.Split(',').ToList();
            var sut = new Order(console, repository); //sut = System under test.
            
            //Act
            sut.PlaceOrder(OrderItemType.Food);
            sut.PlaceOrder(OrderItemType.Drink);
            var totalPrice = sut.CalculateTotalPrice();

            //Assert
            totalPrice.Should().BeApproximately(expectedTotalPrice, 0.004); //Fluent assertions: https://app.pluralsight.com/library/courses/fluent-assertions-improving-unit-tests/table-of-contents
            using (ApprovalResults.ForScenario(testName))
            {
                Approvals.Verify(console.WrittenLines); //Approval Tests: https://app.pluralsight.com/course-player?clipId=23302914-f8f9-4e93-94af-c9420fa8e031
            }
        }
    }
}