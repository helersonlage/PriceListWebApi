using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public abstract class Price
    {
        public abstract decimal CalcDiscount(decimal rate, decimal price);    
    }
}
