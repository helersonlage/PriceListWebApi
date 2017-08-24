using System;

namespace Store.Common
{
    public class PriceDiscount : IPriceDiscount
    {

        public  decimal calcDiscount(decimal rate, decimal price)
        {
            return Math.Round((price - ((rate * price) / 100)),2);
        }

    }
}