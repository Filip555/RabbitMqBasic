using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Messages.Event
{
    public class ReturnedProductList
    {
        public List<Product> ProductList { get; set; } 
    }
}
