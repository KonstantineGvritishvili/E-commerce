using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Shop : ICrud
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine("Product added successfully!");
        }

        public void DeleteProduct(int productId)
        {
            Product productToRemove = null;
            foreach(var product in Products)
            {
                if(product.ProductId == productId)
                {
                    productToRemove = product;
                }
            }
            if(productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
            else
            {
                Console.WriteLine("Product not found");
            }
        }

        public void ShowProducts()
        {
            foreach(var product in Products)
            {
                Console.WriteLine(product);
            }
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;
            foreach(var product in Products)
            {
                totalPrice += product.Price * product.Quantity;
            }
            return totalPrice;
        }

        public void UpdateProduct(Product updatedProduct)
        {
            foreach(var product in Products)
            {
                if(product.ProductId == updatedProduct.ProductId)
                {
                    product.ProductManufacturer = updatedProduct.ProductManufacturer;
                    product.ProductName = updatedProduct.ProductName;
                    product.Price = updatedProduct.Price;
                    product.Quantity = updatedProduct.Quantity;
                    product.Date = updatedProduct.Date;
                    Console.WriteLine("Updated successfully");
                    return;
                }
            }
            Console.WriteLine("Product not found");
        }
    }
}
