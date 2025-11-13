using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Models;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Task SaveProduct(Product product);
        Task<Product?> DeleteProduct(int productId);

        Task UpdateProductDetached(Product product);
    }

}
