﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class SaleItem
    {
        public SaleItem(long id, int quantity, decimal price)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
        }

        public long Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }


    }
}
