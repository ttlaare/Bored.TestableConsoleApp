using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.OrderItemDTOs
{
    public class OrderItemDTO : IOrderItemDTO
    {
        public double Price { get; set; }
        public OrderItemEnum Name { get; set; }
    }
}
