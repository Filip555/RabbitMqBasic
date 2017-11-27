using EasyNetQ;
using Order.Messages;
using System;

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
    }
}
}
