using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.OrderItemDTOs
{
    public interface IOrderItemDTO
    {
        public OrderItemEnum Name { get; set; }
        public double Price { get; set; }

    }
}
