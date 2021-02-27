using System;
using System.Collections.Generic;
using System.Linq;

namespace DataReaderProject
{
    public class OneFile
    {
        public DateTime DateTime { get; set; }
        public List<Record> Records { get; set; }

        public int GetProductsCount()
        {
            return Records.Select(r => r.GetProductCount()).Sum();
        }
        public double GetProductsPrice()
        {
            return Records.Select(r => r.GetProductPrice()).Sum();
        }
    }
}