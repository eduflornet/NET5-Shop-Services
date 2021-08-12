using Microsoft.EntityFrameworkCore;
using ShopService.Api.Book.Model;

namespace ShopService.Api.Book.Persistence
{
    public class ContextLibrary:DbContext
    {
        //It is configured like this to set the connection string from the Startup class
        public ContextLibrary(DbContextOptions<ContextLibrary> options) : base(options) { }
        public DbSet<LibraryMaterial> LibraryMaterial { get; set; }

    }
}
