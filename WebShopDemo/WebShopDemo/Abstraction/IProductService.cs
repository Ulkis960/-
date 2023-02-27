using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopDemo.Domain;
using WebShopDemo.Models.Category;
using WebShopDemo.Models.Product;

namespace WebShopDemo.Abstraction
{
    public interface IProductService
    {
        bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount);
        bool Update(int productId, string name, int brandId, int categoryId,string picture, int quantity, decimal price, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int dogproductId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName);
        object Create(string productName, int brandId, object categoryId, string picture, ProductCreateVM product, object quantity, decimal price, decimal discount);
        object Create(string productName, int brandId, List<CategoryPairVM> categoryId, string picture, int quantity, decimal price, decimal discount);
    }
}
