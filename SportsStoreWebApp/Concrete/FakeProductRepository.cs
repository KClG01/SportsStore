using SportsStore.Domain.Abstract;
using SportsStore.Domain.Models;

public class FakeProductRepository : IProductRepository
{
    public IQueryable<Product> Products => new List<Product>
    {
        // Bóng đá (10 sản phẩm)
        new Product { ProductID = 1, Name = "Bóng đá Adidas Champions League", Description = "Bóng đá chính thức giải Champions League", Price = 45.00m, Category = "Bóng đá" },
        new Product { ProductID = 2, Name = "Bóng đá Nike Premier League", Description = "Bóng đá chính thức giải Premier League", Price = 42.00m, Category = "Bóng đá" },
        new Product { ProductID = 3, Name = "Bóng đá Puma Team Final", Description = "Bóng đá thi đấu chuyên nghiệp", Price = 38.00m, Category = "Bóng đá" },
        new Product { ProductID = 4, Name = "Bóng đá trẻ em Size 3", Description = "Bóng đá dành cho trẻ em", Price = 18.00m, Category = "Bóng đá" },
        new Product { ProductID = 5, Name = "Bóng đá tập luyện Mitre", Description = "Bóng đá chất lượng cho tập luyện", Price = 25.00m, Category = "Bóng đá" },
        new Product { ProductID = 6, Name = "Bóng đá sân cỏ nhân tạo", Description = "Bóng chuyên dụng cho sân cỏ nhân tạo", Price = 35.00m, Category = "Bóng đá" },
        new Product { ProductID = 7, Name = "Bóng đá World Cup 2022", Description = "Bóng đá kỷ niệm World Cup", Price = 55.00m, Category = "Bóng đá" },
        new Product { ProductID = 8, Name = "Bóng đá phủ không thấm nước", Description = "Bóng đá công nghệ chống thấm nước", Price = 40.00m, Category = "Bóng đá" },
        new Product { ProductID = 9, Name = "Bóng đá sân futsal", Description = "Bóng đá chuyên dụng sân trong nhà", Price = 32.00m, Category = "Bóng đá" },
        new Product { ProductID = 10, Name = "Bóng đá cao cấp Select", Description = "Bóng đá thương hiệu Đan Mạch", Price = 48.00m, Category = "Bóng đá" },

        // Quần áo (15 sản phẩm)
        new Product { ProductID = 11, Name = "Áo đấu Barcelona 2023", Description = "Áo đấu sân nhà FC Barcelona", Price = 89.99m, Category = "Quần áo" },
        new Product { ProductID = 12, Name = "Áo đấu Real Madrid 2023", Description = "Áo đấu sân khách Real Madrid", Price = 89.99m, Category = "Quần áo" },
        new Product { ProductID = 13, Name = "Áo đấu Manchester United", Description = "Áo đấu sân nhà MU", Price = 85.99m, Category = "Quần áo" },
        new Product { ProductID = 14, Name = "Áo thể thao Nike Dri-FIT", Description = "Áo tập công nghệ thấm hút mồ hôi", Price = 45.00m, Category = "Quần áo" },
        new Product { ProductID = 15, Name = "Áo thể thao Adidas Climalite", Description = "Áo tập thoáng khí", Price = 42.00m, Category = "Quần áo" },
        new Product { ProductID = 16, Name = "Quần short Nike", Description = "Quần short tập luyện", Price = 35.00m, Category = "Quần áo" },
        new Product { ProductID = 17, Name = "Quần short Adidas", Description = "Quần short thể thao", Price = 32.00m, Category = "Quần áo" },
        new Product { ProductID = 18, Name = "Áo khoác gió Nike Windrunner", Description = "Áo khoác chống gió", Price = 75.00m, Category = "Quần áo" },
        new Product { ProductID = 19, Name = "Áo khoác mưa thể thao", Description = "Áo khoác chống nước", Price = 65.00m, Category = "Quần áo" },
        new Product { ProductID = 20, Name = "Quần dài tập yoga", Description = "Quần tập yoga co giãn", Price = 40.00m, Category = "Quần áo" },
        new Product { ProductID = 21, Name = "Áo ba lỗ thể thao", Description = "Áo tập gym không tay", Price = 25.00m, Category = "Quần áo" },
        new Product { ProductID = 22, Name = "Áo hoodie thể thao", Description = "Áo hoodie giữ ấm", Price = 55.00m, Category = "Quần áo" },
        new Product { ProductID = 23, Name = "Quần bó thể thao", Description = "Quần bó hỗ trợ cơ", Price = 30.00m, Category = "Quần áo" },
        new Product { ProductID = 24, Name = "Áo đấu đội tuyển Việt Nam", Description = "Áo đấu đội tuyển quốc gia", Price = 79.99m, Category = "Quần áo" },
        new Product { ProductID = 25, Name = "Áo thể thao tay dài", Description = "Áo tập mùa đông", Price = 50.00m, Category = "Quần áo" },

        // Giày thể thao (15 sản phẩm)
        new Product { ProductID = 26, Name = "Giày đá bóng Adidas Predator", Description = "Giày đá bóng sân cỏ tự nhiên", Price = 120.00m, Category = "Giày" },
        new Product { ProductID = 27, Name = "Giày đá bóng Nike Mercurial", Description = "Giày đá bóng tốc độ", Price = 130.00m, Category = "Giày" },
        new Product { ProductID = 28, Name = "Giày đá bóng sân cỏ nhân tạo", Description = "Giày chuyên dụng sân cỏ nhân tạo", Price = 85.00m, Category = "Giày" },
        new Product { ProductID = 29, Name = "Giày chạy bộ Nike Air Max", Description = "Giày chạy bộ đệm khí", Price = 110.00m, Category = "Giày" },
        new Product { ProductID = 30, Name = "Giày chạy bộ Adidas Ultraboost", Description = "Giày chạy bộ công nghệ Boost", Price = 125.00m, Category = "Giày" },
        new Product { ProductID = 31, Name = "Giày tập gym New Balance", Description = "Giày tập đa năng", Price = 75.00m, Category = "Giày" },
        new Product { ProductID = 32, Name = "Giày bóng rổ Nike Air Jordan", Description = "Giày bóng rổ cao cấp", Price = 140.00m, Category = "Giày" },
        new Product { ProductID = 33, Name = "Giày bóng rổ Adidas Pro Model", Description = "Giày bóng rổ chuyên nghiệp", Price = 120.00m, Category = "Giày" },
        new Product { ProductID = 34, Name = "Giày tennis Nike Court", Description = "Giày tennis ổn định", Price = 90.00m, Category = "Giày" },
        new Product { ProductID = 35, Name = "Giày đá bóng sân futsal", Description = "Giày futsal đế cao su", Price = 70.00m, Category = "Giày" },
        new Product { ProductID = 36, Name = "Giày chạy địa hình Salomon", Description = "Giày chạy trail running", Price = 115.00m, Category = "Giày" },
        new Product { ProductID = 37, Name = "Giày tập yoga", Description = "Giày tập yoga chống trượt", Price = 45.00m, Category = "Giày" },
        new Product { ProductID = 38, Name = "Giày đá bóng trẻ em", Description = "Giày đá bóng cho trẻ em", Price = 50.00m, Category = "Giày" },
        new Product { ProductID = 39, Name = "Giày thể thao Puma", Description = "Giày thể thao thời trang", Price = 80.00m, Category = "Giày" },
        new Product { ProductID = 40, Name = "Giày đi bộ thể thao", Description = "Giày đi bộ êm ái", Price = 65.00m, Category = "Giày" },

        // Bóng rổ (8 sản phẩm)
        new Product { ProductID = 41, Name = "Bóng rổ Spalding NBA", Description = "Bóng rổ chính thức giải NBA", Price = 65.00m, Category = "Bóng rổ" },
        new Product { ProductID = 42, Name = "Bóng rổ Wilson Evolution", Description = "Bóng rổ thi đấu trong nhà", Price = 60.00m, Category = "Bóng rổ" },
        new Product { ProductID = 43, Name = "Bóng rổ Molten BG5000", Description = "Bóng rổ tiêu chuẩn FIBA", Price = 70.00m, Category = "Bóng rổ" },
        new Product { ProductID = 44, Name = "Bóng rổ trẻ em Size 5", Description = "Bóng rổ cho trẻ em", Price = 25.00m, Category = "Bóng rổ" },
        new Product { ProductID = 45, Name = "Bóng rổ ngoài trời", Description = "Bóng rổ chịu mài mòn", Price = 40.00m, Category = "Bóng rổ" },
        new Product { ProductID = 46, Name = "Bóng rổ cao su", Description = "Bóng rổ cao su bền", Price = 35.00m, Category = "Bóng rổ" },
        new Product { ProductID = 47, Name = "Bóng rổ composite", Description = "Bóng rổ composite", Price = 45.00m, Category = "Bóng rổ" },
        new Product { ProductID = 48, Name = "Bóng rổ thi đấu", Description = "Bóng rổ chuyên nghiệp", Price = 75.00m, Category = "Bóng rổ" },

        // Bóng chuyền (8 sản phẩm)
        new Product { ProductID = 49, Name = "Bóng chuyền Mikasa MVA200", Description = "Bóng chuyền thi đấu quốc tế", Price = 85.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 50, Name = "Bóng chuyền Molten V5M5000", Description = "Bóng chuyền chính thức FIVB", Price = 80.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 51, Name = "Bóng chuyền da tổng hợp", Description = "Bóng chuyền da tổng hợp", Price = 45.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 52, Name = "Bóng chuyền bãi biển", Description = "Bóng chuyền bãi biển", Price = 35.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 53, Name = "Bóng chuyền tập luyện", Description = "Bóng chuyền tập luyện", Price = 30.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 54, Name = "Bóng chuyền trong nhà", Description = "Bóng chuyền sân trong nhà", Price = 40.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 55, Name = "Bóng chuyền cao su", Description = "Bóng chuyền cao su", Price = 25.00m, Category = "Bóng chuyền" },
        new Product { ProductID = 56, Name = "Bóng chuyền hơi", Description = "Bóng chuyền hơi", Price = 20.00m, Category = "Bóng chuyền" },

        // Cầu lông (10 sản phẩm)
        new Product { ProductID = 57, Name = "Vợt cầu lông Yonex Astrox 99", Description = "Vợt cầu lông tấn công", Price = 220.00m, Category = "Cầu lông" },
        new Product { ProductID = 58, Name = "Vợt cầu lông Victor Jetspeed", Description = "Vợt cầu lông tốc độ", Price = 180.00m, Category = "Cầu lông" },
        new Product { ProductID = 59, Name = "Vợt cầu lông Li-Ning Windstorm", Description = "Vợt cầu lông đa năng", Price = 150.00m, Category = "Cầu lông" },
        new Product { ProductID = 60, Name = "Cầu lông vũ thiên nga", Description = "Cầu lông thi đấu", Price = 25.00m, Category = "Cầu lông" },
        new Product { ProductID = 61, Name = "Cầu lông nhựa", Description = "Cầu lông tập luyện", Price = 12.00m, Category = "Cầu lông" },
        new Product { ProductID = 62, Name = "Túi đựng vợt cầu lông", Description = "Túi đựng vợt 6 cây", Price = 45.00m, Category = "Cầu lông" },
        new Product { ProductID = 63, Name = "Giày cầu lông Yonex", Description = "Giày chuyên dụng cầu lông", Price = 95.00m, Category = "Cầu lông" },
        new Product { ProductID = 64, Name = "Vợt cầu lông tập luyện", Description = "Vợt cho người mới bắt đầu", Price = 60.00m, Category = "Cầu lông" },
        new Product { ProductID = 65, Name = "Quả cầu lông cao cấp", Description = "Cầu lông chất lượng cao", Price = 30.00m, Category = "Cầu lông" },
        new Product { ProductID = 66, Name = "Phụ kiện cầu lông", Description = "Bộ dây vợt và grip", Price = 35.00m, Category = "Cầu lông" },

        // Tennis (8 sản phẩm)
        new Product { ProductID = 67, Name = "Vợt tennis Wilson Pro Staff", Description = "Vợt tennis chuyên nghiệp", Price = 250.00m, Category = "Tennis" },
        new Product { ProductID = 68, Name = "Vợt tennis Babolat Pure Drive", Description = "Vợt tennis đa năng", Price = 220.00m, Category = "Tennis" },
        new Product { ProductID = 69, Name = "Vợt tennis Head Graphene", Description = "Vợt tennis công nghệ Graphene", Price = 200.00m, Category = "Tennis" },
        new Product { ProductID = 70, Name = "Bóng tennis Wilson US Open", Description = "Bóng tennis chính thức US Open", Price = 15.00m, Category = "Tennis" },
        new Product { ProductID = 71, Name = "Bóng tennis tập luyện", Description = "Bóng tennis tập luyện", Price = 10.00m, Category = "Tennis" },
        new Product { ProductID = 72, Name = "Túi đựng vợt tennis", Description = "Túi đựng vợt tennis", Price = 55.00m, Category = "Tennis" },
        new Product { ProductID = 73, Name = "Dây vợt tennis", Description = "Dây vợt tennis chính hãng", Price = 25.00m, Category = "Tennis" },
        new Product { ProductID = 74, Name = "Vợt tennis trẻ em", Description = "Vợt tennis cho trẻ em", Price = 80.00m, Category = "Tennis" },

        // Bơi lội (8 sản phẩm)
        new Product { ProductID = 75, Name = "Kính bơi Speedo", Description = "Kính bơi chống mờ", Price = 35.00m, Category = "Bơi lội" },
        new Product { ProductID = 76, Name = "Kính bơi Arena", Description = "Kính bơi thi đấu", Price = 40.00m, Category = "Bơi lội" },
        new Product { ProductID = 77, Name = "Mũ bơi silicon", Description = "Mũ bơi silicon", Price = 15.00m, Category = "Bơi lội" },
        new Product { ProductID = 78, Name = "Mũ bơi vải", Description = "Mũ bơi vải thoáng khí", Price = 12.00m, Category = "Bơi lội" },
        new Product { ProductID = 79, Name = "Quần bơi nam", Description = "Quần bơi nam", Price = 25.00m, Category = "Bơi lội" },
        new Product { ProductID = 80, Name = "Đồ bơi nữ", Description = "Đồ bơi nữ", Price = 45.00m, Category = "Bơi lội" },
        new Product { ProductID = 81, Name = "Phao tay trẻ em", Description = "Phao tay học bơi", Price = 18.00m, Category = "Bơi lội" },
        new Product { ProductID = 82, Name = "Ván bơi", Description = "Ván bơi tập luyện", Price = 22.00m, Category = "Bơi lội" },

        // Phụ kiện (18 sản phẩm)
        new Product { ProductID = 83, Name = "Tất thể thao Nike", Description = "Tất thể thao thấm hút mồ hôi", Price = 12.00m, Category = "Phụ kiện" },
        new Product { ProductID = 84, Name = "Tất thể thao Adidas", Description = "Tất thể thao cổ cao", Price = 10.00m, Category = "Phụ kiện" },
        new Product { ProductID = 85, Name = "Bình nước thể thao 1L", Description = "Bình nước dung tích 1 lít", Price = 18.00m, Category = "Phụ kiện" },
        new Product { ProductID = 86, Name = "Bình nước thể thao 750ml", Description = "Bình nước dung tích 750ml", Price = 15.00m, Category = "Phụ kiện" },
        new Product { ProductID = 87, Name = "Băng đầu gối", Description = "Băng bảo vệ đầu gối", Price = 20.00m, Category = "Phụ kiện" },
        new Product { ProductID = 88, Name = "Băng cổ tay", Description = "Băng bảo vệ cổ tay", Price = 15.00m, Category = "Phụ kiện" },
        new Product { ProductID = 89, Name = "Bao tay tập gym", Description = "Bao tay tập tạ", Price = 25.00m, Category = "Phụ kiện" },
        new Product { ProductID = 90, Name = "Thảm tập yoga", Description = "Thảm tập yoga chống trượt", Price = 35.00m, Category = "Phụ kiện" },
        new Product { ProductID = 91, Name = "Dây nhảy thể dục", Description = "Dây nhảy thể dục", Price = 15.00m, Category = "Phụ kiện" },
        new Product { ProductID = 92, Name = "Balo thể thao", Description = "Balo đựng đồ thể thao", Price = 45.00m, Category = "Phụ kiện" },
        new Product { ProductID = 93, Name = "Túi đeo chéo thể thao", Description = "Túi đeo chéo nhỏ gọn", Price = 30.00m, Category = "Phụ kiện" },
        new Product { ProductID = 94, Name = "Mũ lưỡi trai thể thao", Description = "Mũ lưỡi trai", Price = 22.00m, Category = "Phụ kiện" },
        new Product { ProductID = 95, Name = "Kính thể thao", Description = "Kính bảo vệ mắt", Price = 40.00m, Category = "Phụ kiện" },
        new Product { ProductID = 96, Name = "Đồng hồ thể thao", Description = "Đồng hồ đa năng", Price = 85.00m, Category = "Phụ kiện" },
        new Product { ProductID = 97, Name = "Máy đo nhịp tim", Description = "Máy đo nhịp tim đeo tay", Price = 65.00m, Category = "Phụ kiện" },
        new Product { ProductID = 98, Name = "Bộ sơ cứu thể thao", Description = "Bộ sơ cứu cơ bản", Price = 28.00m, Category = "Phụ kiện" },
        new Product { ProductID = 99, Name = "Băng dán cơ", Description = "Băng dán hỗ trợ cơ", Price = 18.00m, Category = "Phụ kiện" },
        new Product { ProductID = 100, Name = "Khăn thể thao", Description = "Khăn thấm hút tốt", Price = 16.00m, Category = "Phụ kiện" }

    }.AsQueryable();
}