
namespace ConsoleApp.OrderItemDTOs
{
    public class OrderItemDto : IOrderItemDto
    {
        public double Price { get; set; }
        public OrderItem Name { get; set; }
    }
}
