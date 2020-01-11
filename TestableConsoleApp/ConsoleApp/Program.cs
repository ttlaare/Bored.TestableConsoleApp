using ConsoleApp.DataLayer;
using ConsoleApp.Shared.OrderItem;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace ConsoleApp
{

    static class Program
    {
        private static IConfigurationRoot config;

        static void Main()
        {
            StartUp();
            var repository = CreateRepository();
            var resource = new ResourceManager("ConsoleApp.Properties.Resources", Assembly.GetExecutingAssembly());
            var culture = new CultureInfo("nl-NL");
            Thread.CurrentThread.CurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;

            var order = new OrderPlacer(repository, resource);

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
