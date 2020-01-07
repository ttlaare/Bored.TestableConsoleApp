using ConsoleApp.DataLayer;
using ConsoleApp.Shared.OrderItem;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp
{

    static class Program
    {
        private static IConfigurationRoot config;

        static void Main()
        {
            StartUp();
            var repository = CreateRepository();
            var order = new Order(repository);

            order.PlaceOrder(OrderItemType.Food);
            order.PlaceOrder(OrderItemType.Drink);
            order.GetOrderedList();
            order.CalculateTotalPrice();
        }

        private static void StartUp()
        {

            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();
        }

        //TODO Generic where T IOrderItemRepository, New
        private static IOrderItemRepository CreateRepository()
        {
            return new OrderRepositoryDapperSql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
