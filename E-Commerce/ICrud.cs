using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal interface ICrud
    {
        public void AddProduct(Product product);
        public void DeleteProduct(int productId);
        public void ShowProducts();
        public void UpdateProduct(Product updatedProduct);
        public decimal TotalPrice();
    }
}
