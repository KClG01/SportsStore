using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Models;
using SportsStoreWebApp.Extensions;

namespace SportsStoreWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CartController> _logger;
        public CartController(IProductRepository repo,ILogger<CartController> logger)
        {
            _repository = repo;
            _logger = logger;
        }
        [Route("gio-hang/")]
        public IActionResult Index(string returnUrl)
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart")
            ?? new Cart();
            ViewBag.ReturnUrl = returnUrl;
            return View(cart);
        }
        [HttpPost]
        public IActionResult AddToCart(int ProductId, string returnUrl)
        {
            _logger.LogInformation("ProductID: {ProductID}, ReturnURL : {returnurl}", ProductId, returnUrl);
            Product? product = _repository.Products.FirstOrDefault(p =>
            p.ProductID == ProductId);
            if (product != null)
            {
                Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
                cart.AddItem(product, 1);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                _logger.LogInformation("Added product {ProductName} (ID:{ ProductID}) to cart. Total items in cart: { TotalItems}", product.Name, product.ProductID, cart.Lines.Sum(i => i.Quantity));
                TempData["SuccessMessage"] = $"Đã thêm '{product.Name}' vào giỏ hàng!";
            }
            else
            {
                _logger.LogWarning("Attempted to add non-existent product with ID { ProductID} to cart.", ProductId);
            }
            return Redirect(returnUrl ?? "/"); // Chuyển hướng về trang trước
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int ProductId, string returnUrl)
        {
            Product? product = _repository.Products.FirstOrDefault(p =>
            p.ProductID == ProductId);
            if (product != null)
            {
                Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart") ?? new Cart();
                cart.RemoveItem(product);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
                _logger.LogInformation("Removed product {ProductName} (ID:{ ProductID}) from cart.", product.Name, product.ProductID);
                TempData["SuccessMessage"] = $"Đã xóa '{product.Name}' khỏi giỏ hàng!";
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
