namespace ConsoleApp.OrderItems
{
    public class OrderItem : IOrderItem
    {
        public double Price { get; set; }
        public OrderItemType Name { get; set; }
    }
}
