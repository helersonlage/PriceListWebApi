using System;

namespace Common
{
    public class PriceRoundDiscount : Price, IPriceDiscount
    {
        /// <summary>
        /// This method calculates discounts it uses rounding to two decimal places
        /// </summary>
        /// <param name="rate">Discount discountRate</param>
        /// <param name="Amount">Amount </param>
        /// <returns> Amount - (discountRate tax)</returns>
        public override decimal CalcDiscount(decimal discountRate, decimal Amount) => Math.Round((Amount - ((discountRate * Amount) / 100)), 2);
    }
}