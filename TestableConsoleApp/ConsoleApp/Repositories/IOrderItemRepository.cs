using ConsoleApp.OrderItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Repositories
{
    public interface IOrderItemRepository
    {
        public List<OrderItem> OrderItems { get; set; }
    }
}
