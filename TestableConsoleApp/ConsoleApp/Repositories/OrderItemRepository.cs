
using System.Collections.Generic;
using ConsoleApp.OrderItems;

namespace ConsoleApp.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public void AddOrderItem(string name, double price, OrderItemType type)
        {
            OrderItems.Add(new OrderItem()
            {
                Name = name,
                Price = price,
                Type = type
            });
        }
    }
}
