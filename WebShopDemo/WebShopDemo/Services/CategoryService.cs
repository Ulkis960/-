using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopDemo.Abstraction;
using WebShopDemo.Data;
using WebShopDemo.Domain;

namespace WebShopDemo.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> GetCategories(int categoryId)
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
            
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(x => x.CategoryId ==categoryId)
                .ToList();
        }
    }
}
