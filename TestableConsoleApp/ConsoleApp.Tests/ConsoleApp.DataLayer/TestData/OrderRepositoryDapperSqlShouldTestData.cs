using ConsoleApp.Shared.OrderItem;
using ConsoleApp.Tests.ConsoleApp.Helpers;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Tests.ConsoleApp.DataLayer.TestData
{
    static class OrderRepositoryDapperSqlShouldTestData
    {
        public static IEnumerable GetList_WithFilter()
        {
            var orderItems1 = new OrderItemsBuilder()
                .AddOrderItem("Hamburger", 2.95, OrderItemType.Food)
                .AddOrderItem("Grilled Sandwich", 2.45, OrderItemType.Food)
                .Build();
            var orderItems2 = new OrderItemsBuilder()
                .AddOrderItem("Cola", 1.45, OrderItemType.Drink)
                .AddOrderItem("Juice", 1.95, OrderItemType.Drink)
                .Build();
            yield return new TestCaseData(OrderItemType.Food, orderItems1);
            yield return new TestCaseData(OrderItemType.Drink, orderItems2);
        }

        public static IEnumerable GetList()
        {
            var orderItems = new OrderItemsBuilder()
                .AddOrderItem("Hamburger", 2.95, OrderItemType.Food)
                .AddOrderItem("Grilled Sandwich", 2.45, OrderItemType.Food)
                .AddOrderItem("Cola", 1.45, OrderItemType.Drink)
                .AddOrderItem("Juice", 1.95, OrderItemType.Drink)
                .Build();
            yield return new TestCaseData(orderItems);
        }
    }
}
