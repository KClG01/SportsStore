using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Domain.Models;
using SportsStoreWebApp.Extensions;
using System.Text.Json.Serialization;

namespace SportsStoreWebApp.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; } = null!;
        public static Cart GetCart(IServiceProvider service)
        {
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            SessionCart cart = session?.GetObjectFromJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session!;
            return cart;
        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetObjectAsJson("Cart", this);
        }
        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session?.SetObjectAsJson("Cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
