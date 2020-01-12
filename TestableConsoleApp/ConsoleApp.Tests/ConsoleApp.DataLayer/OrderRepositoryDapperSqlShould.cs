using ConsoleApp.DataLayer;
using ConsoleApp.Shared.OrderItem;
using ConsoleApp.Tests.ConsoleApp.DataLayer.TestData;
using ConsoleApp.Tests.ConsoleApp.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsoleApp.Tests.ConsoleApp.DataLayer
{
    class OrderRepositoryDapperSqlShould
    {
        private IOrderItemRepository repository;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var config = ConfigBuilder.Build();
            repository = new OrderRepositoryDapperSql(config.GetConnectionString("DefaultConnection"));
        }

        [Test]
        [TestCaseSource(typeof(OrderRepositoryDapperSqlShouldTestData), "GetList_WithFilter")]
        public void GetList_WithFilter(OrderItemType type, List<OrderItem> expected)
        {
            var actual = repository.GetList(type);
            AssertOrderItems(actual, expected);
        }

        [Test]
        [TestCaseSource(typeof(OrderRepositoryDapperSqlShouldTestData), "GetList")]
        public void GetList(List<OrderItem> expected)
        {
            var actual = repository.GetList();
            AssertOrderItems(actual, expected);
        }

        private void AssertOrderItems(List<OrderItem> actual, List<OrderItem> expected)
        {
            actual.Should().HaveCount(expected.Count);
            for (int i = 0; i < actual.Count; i++)
            {
                actual[i].Name.Should().Be(expected[i].Name);
                actual[i].Price.Should().BeApproximately(expected[i].Price, 0.004);
                actual[i].Type.Should().Be(expected[i].Type);
            }
        }
    }
}
