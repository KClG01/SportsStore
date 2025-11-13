using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsStoreWebApp.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }
        public ViewResult Index() => View(_repository.Products);

        public async Task<IActionResult> Edit(int productId)
        {
            Product? product = await _repository.Products
                .FirstOrDefaultAsync(p =>
            p.ProductID == productId);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} đã được lưu thành công.";
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang Index của Admin
            }
            else
            {
                // Dữ liệu không hợp lệ, hiển thị lại form
                return View(product);
            }
        }
        public ViewResult Create() => View("Edit", new Product());

        [HttpPost]
        public async Task<IActionResult> Delete(int productId)
        {
            Product? deletedProduct = await
            _repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} đã được xóa.";
            }
            else
            {
                TempData["message"] = $"Không tìm thấy sản phẩm có ID: { productId} để xóa.";
            TempData["messageType"] = "danger"; // Báo lỗi
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
