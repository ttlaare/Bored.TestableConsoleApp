using ConsoleApp.OrderItems;
using ConsoleApp.Repositories;

namespace ConsoleApp.Helpers
{
    public static class Factory
    {
        public static OrderItemRepository BuildOrderItemRepository()
        {
            var repository = new OrderItemRepository();
            repository.AddOrderItem("Hamburger", 2.95, OrderItemType.Food);
            repository.AddOrderItem("Grilled Sandwich", 2.45, OrderItemType.Food);
            repository.AddOrderItem("Cola", 1.45, OrderItemType.Drink);
            repository.AddOrderItem("Juice", 1.95, OrderItemType.Drink);
            return repository;
        }
    }
}
