using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using SportsStoreWebApp.Models;
using SportsStoreWebApp.Configurations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SportsStoreWebApp.Controllers
{
    [Route("san-pham")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly PagingSettings _pagingSettings;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductRepository repository, IOptions<PagingSettings> pagingSettings, ILogger<ProductController> logger)
        {
            _repository = repository;
            _pagingSettings = pagingSettings.Value;
            _logger = logger;
        }
        [Route("danh-sach")]
        public IActionResult List(string? category = null, int productPage = 1)
        {
            _logger.LogInformation("=== BẮT ĐẦU ACTION LIST ===");

            // LOG CẤU HÌNH
            _logger.LogInformation("PagingSettings - ItemsPerPage: {ItemsPerPage}", _pagingSettings.ItemsPerPage);

            int itemsPerPage = _pagingSettings.ItemsPerPage;
            _logger.LogInformation("Sử dụng ItemsPerPage: {ItemsPerPage}", itemsPerPage);

            // LOG TỔNG SỐ SẢN PHẨM
            var totalProductsInRepo = _repository.Products.Count();
            _logger.LogInformation("Tổng số sản phẩm trong repository: {TotalProducts}", totalProductsInRepo);

            var productsQuery = _repository.Products
                .Where(p => category == null || p.Category == category);

            var totalFiltered = productsQuery.Count();
            _logger.LogInformation("Số sản phẩm sau khi lọc category '{Category}': {FilteredCount}",
                category ?? "Tất cả", totalFiltered);

            // PHÂN TRANG
            var skip = (productPage - 1) * itemsPerPage;
            _logger.LogInformation("Phân trang: Skip={Skip}, Take={Take}", skip, itemsPerPage);

            var products = productsQuery
                .OrderBy(p => p.ProductID)
                .Skip(skip)
                .Take(itemsPerPage)
                .ToList();

            _logger.LogInformation("Số sản phẩm sẽ hiển thị: {DisplayCount}", products.Count);

            // LOG CHI TIẾT SẢN PHẨM
            _logger.LogInformation("Các sản phẩm sẽ hiển thị:");
            foreach (var p in products)
            {
                _logger.LogInformation(" - ID: {ID}, Name: {Name}, Category: {Category}",
                    p.ProductID, p.Name, p.Category);
            }

            ViewBag.Categories = _repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ViewBag.CurrentCategory = category ?? "Tất cả sản phẩm";
            ViewBag.CurrentPage = productPage;
            ViewBag.TotalItems = totalFiltered;
            ViewBag.ItemsPerPage = itemsPerPage;

            _logger.LogInformation("=== KẾT THÚC ACTION LIST ===");

            return View(products);
        }
        //public IActionResult ListByCategory(string category)
        //{
        //    var products = _repository.Products
        //        .Where(p => category == null || p.Category == category)
        //        .ToList();
        //    ViewBag.CurrentCategory = category ?? "Tất cả sản phẩm";
        //    return View(products);
        //}

        [Route("chi-tiet/{id:int}")]
        public IActionResult Detail(int id)
        {
            var product = _repository.Products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                _logger.LogWarning("Không tìm thấy sản phẩm với ID:{ ProductID}.", id);
                return NotFound();
            }
            _logger.LogInformation("Hiển thị chi tiết sản phẩm ID:{ ProductID}", id);
            return View(product);
        }

        [Route("chinh-sua/{id:int}")]
        public IActionResult Edit(int productId = 0)
        {
            Product? product = productId == 0 ? new Product() : _repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product == null && productId != 0)
            {
                _logger.LogWarning("Không tìm thấy sản phẩm có ID {ProductID} để chỉnh sửa.", productId);
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Dữ liệu sản phẩm cho '{ProductName}' hợp lệ.Sẵn sàng để lưu.", product.Name);TempData["message"] = $"{product.Name} đã được lưu thành công!";
                return RedirectToAction("List");
            }
            else
            {
                _logger.LogWarning("Dữ liệu sản phẩm cho '{ProductName}'không hợp lệ.Lỗi xác thực: { Errors}", product.Name,string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
                return View(product);
            }
        }

        [Route("filter")]
        public IActionResult FilterProducts(ProductFilter filter)
        {
            _logger.LogInformation("Lọc sản phẩm theo Category: {Category}, MinPrice: {MinPrice}, MaxPrice: {MaxPrice}, InStockOnly: {InStock}",
                filter.Category, filter.MinPrice, filter.MaxPrice, filter.InStockOnly);

            var filteredProducts = _repository.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Category))
            {
                filteredProducts = filteredProducts.Where(p => p.Category == filter.Category);
            }
            if (filter.MinPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= filter.MinPrice.Value);
            }
            if (filter.MaxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= filter.MaxPrice.Value);
            }

            // THÊM CÁC DỮ LIỆU CẦN THIẾT CHO VIEW
            ViewBag.Categories = _repository.Products
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToList();

            ViewBag.CurrentCategory = filter.Category ?? "Tất cả sản phẩm";
            ViewBag.CurrentPage = 1;
            ViewBag.TotalItems = filteredProducts.Count();
            ViewBag.ItemsPerPage = _pagingSettings.ItemsPerPage;

            return View("List", filteredProducts.ToList());
        }
    }
}
