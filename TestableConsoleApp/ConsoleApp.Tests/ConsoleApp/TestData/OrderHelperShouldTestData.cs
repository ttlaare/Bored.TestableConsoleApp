﻿using ConsoleApp.Shared.OrderItem;
using ConsoleApp.Tests.ConsoleApp.Helpers;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp.Tests.ConsoleApp.TestData
{
    public class OrderHelperShouldTestData
    {
        public static IEnumerable WriteOrderableItemsTestCases()
        {
            var orderableItems1 = new OrderItemsBuilder()
                .AddOrderItem("Hamburger", 2.95, OrderItemType.Food)
                .Build();

            var orderableItems2 = new OrderItemsBuilder()
                .AddOrderItems(orderableItems1)
                .AddOrderItem("cola", 1.45, OrderItemType.Drink)
                .Build();

            yield return new TestCaseData(orderableItems1, "en-GB", "TestCase1");
            yield return new TestCaseData(orderableItems1, "nl-NL", "TestCase2");
            yield return new TestCaseData(orderableItems2, "en-GB", "TestCase3");
            yield return new TestCaseData(orderableItems2, "nl-NL", "TestCase4");
        }

        public static IEnumerable AddOrderByUser()
        {
            var orderableItems1 = new OrderItemsBuilder()
                .AddOrderItem("Hamburger", 2.95, OrderItemType.Food)
                .Build();

            var orderableItems2 = new OrderItemsBuilder()
                .AddOrderItems(orderableItems1)
                .AddOrderItem("cola", 1.45, OrderItemType.Drink)
                .Build();

            yield return new TestCaseData("1", orderableItems1, 0);
            yield return new TestCaseData("2", orderableItems2, 1);

        }

        //public static IEnumerable ThrowException_When_InvalidInput_AddOrderByUser()
        //{
        //    var orderableItems = new OrderItemsBuilder()
        //        .AddOrderItem("Hamburger", 2.95, OrderItemType.Food)
        //        .Build();

        //    yield return new TestCaseData("3", orderableItems, typeof(ArgumentOutOfRangeException));
        //    yield return new TestCaseData("2.5", orderableItems, FormatException);
        //}
    }
}
