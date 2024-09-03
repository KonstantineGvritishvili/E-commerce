using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Buy : IBuy
    {
        public List<(Product Product, int UserId)> SoldItems { get; set; } = new List<(Product Product, int UserId)>();

        public void BuyProduct(Product product, int userId, int quantity)
        {
            if(product.Quantity >= quantity)
            {
                product.Quantity -= quantity;
                SoldItems.Add((product, userId));
                Console.WriteLine("Product Bought");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public void ShowSoldProducts()
        {
            Console.WriteLine("Sold product:");
            foreach(var item in SoldItems)
            {
                Console.WriteLine($"{item.Product.ProductId}, {item.Product.ProductName}, sold to {item.UserId}");
            }
        }
    }
}
