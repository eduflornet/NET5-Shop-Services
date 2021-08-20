using Microsoft.EntityFrameworkCore;
using ShopService.Api.ShoppingCart.Model;
using DbContext = System.Data.Entity.DbContext;

namespace ShopService.Api.ShoppingCart.Persistence
{
    public class CartContext:DbContext
    {
        public CartContext(DbContextOptions<CartContext> options):base(options) { }
        public DbSet<CartSession> CartSession { get; set; }
        public DbSet<ShoppingCartSessionDetail> ShoppingCartSessionDetail { get; set; }

    }
}
