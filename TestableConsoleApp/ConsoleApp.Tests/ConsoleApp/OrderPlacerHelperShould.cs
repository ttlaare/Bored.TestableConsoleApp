using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ConsoleApp.Shared.OrderItem;
using ConsoleApp.Tests.ConsoleApp.Helpers;
using ConsoleApp.Tests.ConsoleApp.TestData;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace ConsoleApp.Tests
{
    public class OrderPlacerHelperShould
    {
        private ResourceManager resource;

        [SetUp]
        public void SetUp()
        {
            resource = new ResourceManager("ConsoleApp.Properties.Resources", Assembly.Load("ConsoleApp"));
        }

        [Test]
        [UseApprovalSubdirectory("OrderPlacerHelperShould.ApprovedFiles")]
        [UseReporter(typeof(DiffReporter))]
        [TestCaseSource(typeof(OrderHelperShouldTestData), "WriteOrderableItemsTestCases")]
        public void WriteOrderableItems(List<OrderItem> orderableItems, string cultureInput, string testName)
        {
            //Arrange
            CultureSetter.SetCulture(cultureInput);
            using var consoleOutput = new ConsoleOutput();

            //Act
            OrderPlacerHelper.WriteOrderableItems(orderableItems, resource);

            //Assert
            using (ApprovalResults.ForScenario(testName))
            {
                Approvals.Verify(consoleOutput.GetOuput());
            }
        }

        [Test]
        [TestCaseSource(typeof(OrderHelperShouldTestData), "AddOrderByUser")]
        public void AddOrderByUser(string input, List<OrderItem> orderableItems, int expectedIndex)
        {
            //Arrange
            var expected = orderableItems.ElementAt(expectedIndex);

            //Act
            var actual = OrderPlacerHelper.AddOrderByUser(input, orderableItems);

            actual.Name.Should().Be(expected.Name);
            actual.Price.Should().BeApproximately(expected.Price,0.004);
            actual.Type.Should().Be(expected.Type);
        }

        [Test]
        public void ThrowFormatException_When_AddOrderByUse_And_InputIncorrentFormat()
        {
            var orderableItems = new OrderItemsBuilder().AddOrderItem("Hamburger", 2.95, OrderItemType.Food).Build();
            Action act = () => OrderPlacerHelper.AddOrderByUser("0.5", orderableItems);

            act.Should().Throw<FormatException>();
        }

        [Test]
        public void ThrowArgumentOutOfRangeException_When_AddOrderByUse_And_InputOutOfRange()
        {
            var orderableItems = new OrderItemsBuilder().AddOrderItem("Hamburger", 2.95, OrderItemType.Food).Build();
            Action act = () => OrderPlacerHelper.AddOrderByUser("2", orderableItems);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
