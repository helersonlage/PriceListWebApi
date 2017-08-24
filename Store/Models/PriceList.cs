using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class PriceList : IPriceList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal PriceFull { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal price { get; set; }
    }
}