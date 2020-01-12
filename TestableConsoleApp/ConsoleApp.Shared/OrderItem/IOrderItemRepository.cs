using System.Collections.Generic;

namespace ConsoleApp.Shared.OrderItem
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetList();
        List<OrderItem> GetList(OrderItemType type);
    }
}
