using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using EasyNetQ;
using Newtonsoft.Json;
using Order.Messages;
using Order.Messages.Command;
using Order.Messages.Event;

namespace Rabbit.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public HttpResponseMessage Post([FromBody] Product order)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost");

            messageBus.Publish(order);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
        [HttpGet]
        public JsonResult Get(int listCount)
        {
            var messageBus = RabbitHutch.CreateBus("host=localhost");

            var response = messageBus.Request<ReturnProductList, ReturnedProductList>(new ReturnProductList
            {
                Records = 5
            });

            return Json(JsonConvert.SerializeObject(response));
        }
    }

}