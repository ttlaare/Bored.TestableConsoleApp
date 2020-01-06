using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ConsoleApp.Helpers;
using ConsoleApp.OrderItems;
using ConsoleApp.Repositories;
using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Text;

namespace ConsoleApp.Tests
{
    public class OrderShould
    {
        private OrderItemRepository repository;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            repository = Factory.BuildOrderItemRepository();
        }

        [Test]
        [UseApprovalSubdirectory("OrderShould.ApprovedFiles")]
        [UseReporter(typeof(DiffReporter))]
        [TestCase("1,1", 4.4, "Test1")]
        [TestCase("1,2", 4.9, "Test2")]
        [TestCase("2,1", 3.9, "Test3")]
        [TestCase("2,2", 4.4, "Test4")]
        public void CalculateTotalPriceCorrectly(string input, double expectedTotalPrice, string testName)
        {
            //Arrange
            var inputList = input?.Split(',').ToList();
            var sb = new StringBuilder();
            foreach (var line in inputList)
                sb.AppendLine(line);

            var sut = new Order(repository); //sut = System under test.

            //Act
            using (var consoleInput = new ConsoleInput(sb.ToString()))
            using (var consoleOutput = new ConsoleOutput())
            {
                sut.PlaceOrder(OrderItemType.Food);
                sut.PlaceOrder(OrderItemType.Drink);
                sut.GetOrderedList();
                var totalPrice = sut.CalculateTotalPrice();

                //Assert
                totalPrice.Should().BeApproximately(expectedTotalPrice, 0.004); //Fluent assertions: https://app.pluralsight.com/library/courses/fluent-assertions-improving-unit-tests/table-of-contents
                using (ApprovalResults.ForScenario(testName))
                {
                    Approvals.Verify(consoleOutput.GetOuput()); //Approval Tests: https://app.pluralsight.com/course-player?clipId=23302914-f8f9-4e93-94af-c9420fa8e031
                }
            }
        }
    }
}
