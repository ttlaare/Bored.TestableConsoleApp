
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ToDo: Refactor naming 
            //ToDo: 
            //ToDo: Add Repository
            var console = new ConsoleWrapper();
            var order = new Order(console);
            order.PlaceFoodOrder();
            order.PlaceDrinkOrder();
            order.CalculateTotalPrice();
        }
    }
}
