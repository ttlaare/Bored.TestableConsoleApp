using ConsoleApp.Shared.OrderItem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace ConsoleApp
{
    static class OrderPlacerHelper
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "<Pending>")]
        public static void WriteOrderableItems(List<OrderItem> orderableItems, ResourceManager resource)
        {
            if (resource == null)
                throw new ArgumentNullException(nameof(resource));

            if (orderableItems == null)
                throw new ArgumentNullException(nameof(orderableItems));

            Console.WriteLine(resource.GetString("ConsoleApp_Order_OrderMessage", CultureInfo.CurrentCulture));
            for (int i = 0; i < orderableItems.Count; i++)
            {
                Console.WriteLine($"Press {i + 1} for a {orderableItems.ElementAt(i).Name.ToLower(CultureInfo.InvariantCulture)}. " +
                    $"Price: {orderableItems.ElementAt(i).Price.ToString("F", CultureInfo.CurrentCulture)}.");
            }
        }

        public static OrderItem AddOrderByUser(string input, List<OrderItem> orderableItems)
        {
            var index = int.Parse(input, CultureInfo.InvariantCulture) - 1;
            return orderableItems.ElementAt(index);
        }
    }
}
