namespace ConsoleApp.OrderItems
{
    public interface IOrderItem
    {
        public OrderItemType Name { get; set; }
        public double Price { get; set; }

    }
}
