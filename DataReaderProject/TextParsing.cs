using System;
using System.Collections.Generic;
using System.Linq;

namespace DataReaderProject
{
    public class TextParsing
    {
        public static IEnumerable<Record> ParsText(string text)
        {
            if (text == null) throw new ArgumentException(nameof(text));
            var records = new List<Record>();
            var splitRecordText = text.Split(new[] {"Id="}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var itemText in splitRecordText)
            {
                var productItems = itemText.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
                var id = 0;
                id = int.Parse(productItems[0]);
                var products = ParsProduct(productItems);
                records.Add(new Record() {Id = id, Products = products.ToList()});
            }

            return records;
        }

        public static IEnumerable<Product> ParsProduct(IEnumerable<string> item)
        {
            var products = new List<Product>();
            foreach (var i in item.Skip(1))
            {
                var product = i.Replace("[product=", "")
                    .Replace("]", "")
                    .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                var productName = product.First();
                var price = 0d;
                try
                {
                    price = double.Parse(product[1]
                        .Replace(" price=", ""));
                }
                catch (Exception e) { }
                products.Add(new Product(){Name = productName, Price = price});
            }
            return products;
        }
    }
}