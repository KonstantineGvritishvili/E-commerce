using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{ProductId} {ProductManufacturer} {ProductName} {Price} {Date} {Quantity}";
        }
    }
}
