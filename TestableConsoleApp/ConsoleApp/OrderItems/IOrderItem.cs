namespace ConsoleApp.OrderItems
{
    public interface IOrderItem
    {
        public OrderItemType Type { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
    }
}
