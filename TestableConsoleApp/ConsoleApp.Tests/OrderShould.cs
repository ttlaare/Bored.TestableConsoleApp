using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ConsoleApp.DataLayer;
using ConsoleApp.Shared.OrderItem;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;

namespace ConsoleApp.Tests
{
    public class OrderShould
    {
        private IOrderItemRepository repository;
        private static IConfigurationRoot config;

        //Add Test Database
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            StartUp();
            repository = CreateRepository();
        }

        [Test]
        [UseApprovalSubdirectory("OrderShould.ApprovedFiles")]
        [UseReporter(typeof(DiffReporter))]
        [TestCase("1,1", 4.4, "en-GB","Test1")]
        [TestCase("1,2", 4.9, "en-GB", "Test2")]
        [TestCase("2,1", 3.9, "en-GB", "Test3")]
        [TestCase("2,2", 4.4, "nl-NL", "Test4")]
        public void CalculateTotalPriceCorrectly(string input, double expectedTotalPrice, string cultureInput, string testName)
        {
            //Arrange
            var inputList = input?.Split(',').ToList();
            var sb = new StringBuilder();
            foreach (var line in inputList)
                sb.AppendLine(line);

            var resource = new ResourceManager("ConsoleApp.Properties.Resources", Assembly.Load("ConsoleApp"));
            var culture = new CultureInfo(cultureInput);
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            var sut = new Order(repository, resource); //sut = System under test.

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
        public static void StartUp()
        {

            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
             config = builder.Build();
        }

        private static OrderRepositoryDapperSql CreateRepository()
        {
            return new OrderRepositoryDapperSql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
