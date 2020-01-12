using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ConsoleApp.DataLayer;
using ConsoleApp.Shared.OrderItem;
using ConsoleApp.Tests.ConsoleApp.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using System.Resources;

namespace ConsoleApp.Tests
{
    class OrderPlacerShould
    {
        private IOrderItemRepository repository;
        private IConfigurationRoot config;
        private ResourceManager resource;

        //Add Test Database
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartUp();
            repository = CreateRepository();
            resource = new ResourceManager("ConsoleApp.Properties.Resources", Assembly.Load("ConsoleApp"));
        }

        [Test]
        [UseApprovalSubdirectory("OrderPlacerShould.ApprovedFiles")]
        [UseReporter(typeof(DiffReporter))]
        [TestCase("1,1", 4.4, "en-GB","Test1")]
        [TestCase("1,2", 4.9, "en-GB", "Test2")]
        [TestCase("2,1", 3.9, "en-GB", "Test3")]
        [TestCase("2,2", 4.4, "nl-NL", "Test4")]
        public void CalculateTotalPriceCorrectly(string input, double expectedTotalPrice, string cultureInput, string testName)
        {
            //Arrange
            var consoleStringInput = ConsoleInputBuilder.Build(input);
            CultureSetter.SetCulture(cultureInput);

            var sut = new OrderPlacer(repository, resource); //sut = System under test.

            //Act
#pragma warning disable S1481 // Unused local variables should be removed
            using var consoleInput = new ConsoleInput(consoleStringInput); //Exceptions: Unused locally created resources in a using statement are not reported.
#pragma warning restore S1481 // Unused local variables should be removed
            using var consoleOutput = new ConsoleOutput();
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
        public void StartUp()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
             config = builder.Build();
        }

        private OrderRepositoryDapperSql CreateRepository()
        {
            return new OrderRepositoryDapperSql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
