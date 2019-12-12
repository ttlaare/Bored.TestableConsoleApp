namespace ConsoleApp.OrderItems
{
    public class OrderItem : IOrderItem
    {
        public double Price { get; set; }
        public OrderItemType Type { get; set; }
        public string Name { get; set; }
    }
}
