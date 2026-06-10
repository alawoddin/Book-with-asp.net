using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boo.Business.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductAsync(bool includeCategory=false);

        Task<Product?> GetProductByIdAsync(int id);

        Task<Product> CreateProductAsync(Product category);

        Task<Product?> UpdateProductAsync(Product category);

        Task<bool> DeleteProductAsync(int id);


    }
}
