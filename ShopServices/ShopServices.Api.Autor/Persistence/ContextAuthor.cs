using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Author.Model;

namespace ShopServices.Api.Author.Persistence
{
    public class ContextAuthor:DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) { }
        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Degree> Degree { get; set; }
    }
}
