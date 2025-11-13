
using SportsStore.Domain.Abstract;
using SportsStoreWebApp.Configurations;

namespace SportsStoreWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Add services to the container.
            

            builder.Services.Configure<PagingSettings>(builder.Configuration.GetSection("PagingSettings"));

            builder.Services.AddScoped<IProductRepository, FakeProductRepository>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "SportsStore.Session";
            });

            var app = builder.Build();

            app.UseMiddleware<SportsStoreWebApp.Middleware.RequestLoggerMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Trang lỗi chi tiết cho dev
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "product_by_category",
            //    pattern: "san-pham/danh-muc/{category}",
            //    defaults: new { controller= "Product", action = "List" }
            //    );

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //Console.WriteLine("=== Thực hành C# cơ bản ===");

            //List<SportsStoreWebApp.Models.Product> sampleProducts = new List<SportsStoreWebApp.Models.Product>
            //{
            //    new SportsStoreWebApp.Models.Product { ProductID = 1, Name = "Bóng đá World Cup", Description = "Bóng đá chính hãng", Price = 50.00m, Category = "Bóng đá" },
            //    new SportsStoreWebApp.Models.Product { ProductID = 2, Name = "Áo đấu CLB A", Description = "Áo đấu cho người hâm mộ", Price = 75.50m, Category = "Quần áo" },
            //    new SportsStoreWebApp.Models.Product { ProductID = 3, Name = "Vợt Tennis Pro", Description = "Vợt chuyên nghiệp", Price = 150.00m, Category = "Tennis" },
            //    new SportsStoreWebApp.Models.Product { ProductID = 4, Name = "Giày chạy bộ ABC", Description = "Giày thể thao nhẹ", Price = 99.99m, Category = "Giày" },
            //    new SportsStoreWebApp.Models.Product { ProductID = 5, Name = "Bóng rổ NBA", Description = "Bóng rổ tiêu chuẩn", Price = 45.00m, Category = "Bóng rổ" }
            //};

            //Console.WriteLine("\n---LINQ: lọc sản phẩm có giá trên 70 ---");
            //var expensiveProducts = sampleProducts.Where(p => p.Price > 70.00m);
            //foreach (var p in expensiveProducts)
            //{
            //    Console.WriteLine($"--{p.Name} : {p.Price}");
            //}
            //Console.WriteLine("\n---LINQ: lấy sản phẩm đầu tiên category bóng đá ---");
            //var firstfootballProduct = sampleProducts.FirstOrDefault(p => p.Category == "Bóng đá");
            //if (firstfootballProduct != null)
            //{
            //    Console.WriteLine($"--{firstfootballProduct.Name} : {firstfootballProduct.Price}");
            //}
            //else
            //{
            //    Console.WriteLine("--Không tìm thấy sản phẩm nào trong category bóng đá");
            //}
            //Console.WriteLine("\n---Async/Await: Mô phỏng thao tác bất đồng bộ ---");

            //async Task simulateDataFetchAsync()
            //{
            //    Console.WriteLine("Đang bắt đầu lấy dữ liệu (mất 2 giây)...");
            //    await Task.Delay(2000);
            //    Console.WriteLine("Đã lấy data thành công!");
            //}

            //await simulateDataFetchAsync();

            //Console.WriteLine("===Kết thúc C#");

            app.MapControllerRoute(
                name: "category_page",
                pattern: "{category}/Page{productPage:int}",
                defaults: new { controller = "Product", action = "List" }
            );


            app.MapControllerRoute(
                name: "pagination",
                pattern: "Page{productPage:int}",
                defaults: new { controller = "Product", action = "List", category = (string?)null }
            );

            app.MapControllerRoute(
                name: "category",
                pattern: "{category}",
                defaults: new { controller = "Product", action = "List", productPage = 1 }
            );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
