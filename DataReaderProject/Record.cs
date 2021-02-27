using System.Collections.Generic;
using System.Linq;

namespace DataReaderProject
{
    public class Record
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public int GetProductCount()
        {
            return Products.Count;
        }

        public double GetProductPrice()
        {
            return Products.Select(p => p.Price).Sum();
        }
    }
}