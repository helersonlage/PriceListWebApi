using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Store.Models;
using Store.Common;

namespace Store.Controllers
{
    [Authorize]
    public class PriceListController : ApiController
    {
        private StoreEntities db = new StoreEntities();

        // GET: api/PriceList
        [ResponseType(typeof(List<IPriceList>))]
        public IHttpActionResult GetPriceList(DateTime date)
        {
            var lst = checkDiscount(date, db.Products.ToList());
            return Ok(lst);
        }


        private List<IPriceList> checkDiscount(DateTime date, List<Product> products)
        {
            List<IPriceList> priceLists = new List<IPriceList>();
            IPriceList itemPriceLst = new PriceList();
            IPriceDiscount pDiscount = new PriceDiscount();

            foreach (var item in products)
            {
                itemPriceLst = new PriceList();
                itemPriceLst.ID = item.ID;
                itemPriceLst.Name = item.Name;
                itemPriceLst.PriceFull = item.Price;

                var discount = item.Discounts.Where(p => date >=  p.InitialDate && date <= p.FinalDate).SingleOrDefault();

                if (discount != null && discount.DiscountRate > 0)
                {
                    itemPriceLst.price = pDiscount.calcDiscount(discount.DiscountRate, item.Price);
                    itemPriceLst.DiscountRate = discount.DiscountRate;
                }
                else
                {
                    itemPriceLst.price = item.Price;
                }

                priceLists.Add(itemPriceLst);

            }

            return priceLists;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.ID == id) > 0;
        }
    }
}