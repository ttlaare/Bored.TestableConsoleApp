using ConsoleApp.OrderItems;
using System.Collections.Generic;

namespace ConsoleApp.Repositories
{
    public interface IOrderItemRepository
    {
        public List<OrderItem> OrderItems { get; set; }
    }
}
