using SportsStore.Domain.Abstract;
using SportsStore.Domain.Models;
using SportsStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;

        // SỬA: Thêm Async cho khớp interface
        public async Task SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                await _context.Products.AddAsync(product);
            }
            else
            {
                var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(p => p.ProductID == product.ProductID);

                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Category = product.Category;
                    existingProduct.ImageUrl = product.ImageUrl;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product?> DeleteProduct(int productId)
        {
            Product? dbEntry = await _context.Products.FirstOrDefaultAsync(p =>
            p.ProductID == productId);
            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry); // Đánh dấu đối tượng để xóa
                await _context.SaveChangesAsync(); // Lưu thay đổi vào DB (thực hiện DELETE)
            }
            return dbEntry; // Trả về đối tượng đã xóa hoặc null nếu không tìm thấy
        }
        public async Task UpdateProductDetached(Product product)
        {
            _context.Products.Update(product); // Đánh dấu đối tượng là Modified
            await _context.SaveChangesAsync();
        }
    }
}
