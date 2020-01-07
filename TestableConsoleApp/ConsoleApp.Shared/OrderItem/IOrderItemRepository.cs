using System.Collections.Generic;

namespace ConsoleApp.Shared.OrderItem
{
    public interface IOrderItemRepository
    {
        List<OrderItem> GetList();
        //TODO GetList(bool,FUNC,WHERE expression)
    }
}
