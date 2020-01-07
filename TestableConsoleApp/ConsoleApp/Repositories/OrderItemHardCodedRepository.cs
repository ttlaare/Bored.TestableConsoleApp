
using System.Collections.Generic;
using ConsoleApp.Shared.OrderItem;

namespace ConsoleApp.Repositories
{
    public class OrderItemHardCodedRepository : IOrderItemRepository
    {
        private readonly List<OrderItem> orderItems = new List<OrderItem>();
        public void AddOrderItem(string name, double price, OrderItemType type)
        {
            orderItems.Add(new OrderItem()
            {
                Name = name,
                Price = price,
                Type = type
            });
        }

        public List<OrderItem> GetList()
        {
            return orderItems;
        }
    }
}
