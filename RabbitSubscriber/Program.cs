using EasyNetQ;
using Order.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using Order.Messages.Command;
using Order.Messages.Event;

namespace RabbitSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost");
            messageBus.Subscribe<Product>("SubscriptionId", msg =>
                {
                    Console.WriteLine($"Product :{msg.ProductName} costs {msg.Price}");
                });

            messageBus.Respond<ReturnProductList, ReturnedProductList>(request => new ReturnedProductList
            {
                ProductList = GenerateProductList().Take(request.Records).ToList()
            });
        }
        public static List<Product> GenerateProductList()
        {
            var productList = new List<Product>()
            {
                new Product
                {
                    Price = 10,
                    ProductName = "T1"
                },
                new Product
                {
                    Price = 12,
                    ProductName = "T2"
                },
                new Product
                {
                    Price = 15,
                    ProductName = "T3"
                },
                new Product
                {
                    Price = 13,
                    ProductName = "T4"
                },
                new Product
                {
                    Price = 5,
                    ProductName = "T5"
                },
                new Product
                {
                    Price = 9,
                    ProductName = "T6"
                },
                new Product
                {
                    Price = 19,
                    ProductName = "T7"
                },
        };
            return productList;
        }
    }
}
