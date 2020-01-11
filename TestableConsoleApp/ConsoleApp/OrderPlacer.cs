using ConsoleApp.Shared.OrderItem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;

namespace ConsoleApp
{
    public class OrderPlacer
    {
        private readonly IOrderItemRepository repository;
        private readonly ResourceManager resource;
        private readonly List<OrderItem> placedOrderItems = new List<OrderItem>();

        //TODO Let user choose if they want to order food or drinks
        public OrderPlacer(IOrderItemRepository repository, ResourceManager resource)
        {
            this.repository = repository;
            this.resource = resource;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "<Pending>")]
        public void PlaceOrder(OrderItemType type)
        {
            var orderableItems = repository.GetList().Where(o => o.Type == type).ToList(); //BL
            OrderPlacerHelper.WriteOrderItems(orderableItems, resource);
            ReadOrderFromUser();

            //void WriteOrderItems() //UI
            //{
            //    Console.WriteLine(resource.GetString("ConsoleApp_Order_OrderMessage", Thread.CurrentThread.CurrentCulture));
            //    for (int i = 0; i < orderableItems.Count(); i++)
            //    {
            //        Console.WriteLine($"Press {i + 1} for a {orderableItems.ElementAt(i).Name.ToLower(CultureInfo.InvariantCulture)}. " +
            //            $"Price: {orderableItems.ElementAt(i).Price.ToString("F", CultureInfo.CurrentCulture)}.");
            //    }
            //}

            void ReadOrderFromUser()//UI
            {
                int consoleInput;
                while (true)
                {
                    try
                    {
                        consoleInput = int.Parse(Console.ReadLine()) - 1;
                        placedOrderItems.Add(orderableItems.ElementAt(consoleInput)); //BL
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"Invalid input: input is out of range. Please choose a number between 1 and {orderableItems.Count()}.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid input: input is not numeric. Please choose a number between 1 and {orderableItems.Count()}.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Sorry. Something unexpected happened. Exception message:{e.Message}");
                        throw;
                    }
                }
            }
        }

        public void GetOrderedList() //UI
        {
            if (!placedOrderItems.Any())
            {
                Console.WriteLine("You haven't placed an order yet");
                return;
            }

            Console.WriteLine("You ordered:");
            foreach (var item in placedOrderItems)
            {
                Console.WriteLine(item.Name);
            }
        }

        public double CalculateTotalPrice() //BL
        {
            var result = placedOrderItems.Select(o => o.Price).Sum();
            Console.WriteLine($"Total price is: {result.ToString("F",CultureInfo.CurrentCulture)}");
            return result;
        }
    }
}
