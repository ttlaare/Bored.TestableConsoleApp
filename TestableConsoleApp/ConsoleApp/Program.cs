using ConsoleApp.OrderItems;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    static class Program
    {
        static void Main()
        {
            var repository = Factory.BuildOrderItemRepository();
            var order = new Order(repository);

            order.PlaceOrder(OrderItemType.Food);
            order.PlaceOrder(OrderItemType.Drink);
            order.GetOrderedList();
            order.CalculateTotalPrice();
        }
    }
}
