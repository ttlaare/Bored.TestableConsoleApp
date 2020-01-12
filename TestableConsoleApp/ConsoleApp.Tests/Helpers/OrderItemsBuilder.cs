using ConsoleApp.Shared.OrderItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Tests.ConsoleApp.Helpers
{
    public class OrderItemsBuilder
    {
        private readonly List<OrderItem> orderItems = new List<OrderItem>();

        public OrderItemsBuilder AddOrderItem(string name, double price, OrderItemType type)
        {
            orderItems.Add(new OrderItem
            {
                Name = name,
                Price = price,
                Type = type
            });
            return this;
        }

        public OrderItemsBuilder AddOrderItems(List<OrderItem> orderItems)
        {
            this.orderItems.AddRange(orderItems);
            return this;
        }

        public List<OrderItem> Build() => orderItems;
    }
}
