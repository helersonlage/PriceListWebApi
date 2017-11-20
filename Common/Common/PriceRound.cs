using System;

namespace Common
{
    public class PriceDiscount: Price, IPriceDiscount
    {
        /// <summary>
        /// This method calculates discounts it NOt  uses rounding to two decimal places
        /// </summary>
        /// <param name="rate">Discount discountRate</param>
        /// <param name="Amount">Amount </param>
        /// <returns> Amount - (discountRate tax)</returns>
        public override decimal CalcDiscount(decimal discountRate, decimal Amount) => Amount - ((discountRate /100) * Amount);
    }
}