using ConsoleApp.Shared.OrderItem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

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
            OrderPlacerHelper.WriteOrderableItems(orderableItems, resource);
            ReadOrderFromUser();

            void ReadOrderFromUser()//UI
            {
                OrderItem placedOrder;
                while (true)
                {
                    try
                    {
                        placedOrder = OrderPlacerHelper.AddOrderByUser(Console.ReadLine(), orderableItems);
                        placedOrderItems.Add(placedOrder);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine($"Invalid input: input is out of range. Please choose a number between 1 and {orderableItems.Count}.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Invalid input: input is not numeric. Please choose a number between 1 and {orderableItems.Count}.");
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
