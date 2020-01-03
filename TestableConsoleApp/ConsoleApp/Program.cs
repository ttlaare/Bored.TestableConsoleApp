using ConsoleApp.OrderItems;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    static class Program
    {
        static void Main()
        {

            var repository = Factory.BuildOrderItemRepository();
            var console = new ConsoleWrapper();
            var order = new Order(console, repository);

            order.PlaceOrder(OrderItemType.Food);
            order.PlaceOrder(OrderItemType.Drink);
            order.GetOrderedList();
            order.CalculateTotalPrice();
        }
    }
}
