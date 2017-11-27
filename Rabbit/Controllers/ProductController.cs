using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using EasyNetQ;
using Order.Messages;

namespace Rabbit.Controllers
{
    public class ProductController : Controller
    {
        public HttpResponseMessage Post([FromBody] Product order)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost");

            messageBus.Publish(order);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }

}