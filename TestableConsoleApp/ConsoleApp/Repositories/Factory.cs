using ConsoleApp.Shared.OrderItem;

namespace ConsoleApp.Repositories
{
    public static class Factory
    {
        public static OrderItemHardCodedRepository BuildOrderItemRepository()
        {
            var repository = new OrderItemHardCodedRepository();
            repository.AddOrderItem("Hamburger", 2.95, OrderItemType.Food);
            repository.AddOrderItem("Grilled Sandwich", 2.45, OrderItemType.Food);
            repository.AddOrderItem("Cola", 1.45, OrderItemType.Drink);
            repository.AddOrderItem("Juice", 1.95, OrderItemType.Drink);
            return repository;
        }
    }
}
