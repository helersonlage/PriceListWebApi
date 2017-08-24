using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests.Data
{
    public class ProductTeste
    {

        public Product GetTestProduct()
        {

            return new Product { Name = "Teste_!@#$%^&*(098)", Price = 1000, };

        }


    }
}
