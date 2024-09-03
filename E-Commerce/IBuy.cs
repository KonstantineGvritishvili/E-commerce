using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal interface IBuy
    {
        public void ShowSoldProducts();
        public void BuyProduct(Product product, int userId, int quantity);
    }
}
