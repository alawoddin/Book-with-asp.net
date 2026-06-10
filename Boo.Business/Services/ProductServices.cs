using Boo.Business.Services.IServices;
using Book.Data;
using Book.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boo.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool includeCategory=false)
        {
            if(includeCategory)
            {
                return await _context.Products.Include(u=>u.Category).ToListAsync();
            }
            else
            {

            }
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);

        }


        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                throw new KeyNotFoundException($"Product {id} not found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;

        }

        

        public async Task<Product?> UpdateProductsAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public Task<IEnumerable<Product>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> UpdateProductAsync(Product category)
        {
            throw new NotImplementedException();
        }
    }
}
