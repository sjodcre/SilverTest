using Microsoft.EntityFrameworkCore;
using SilverTest.API.Models;

namespace SilverTest.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}      
        
        public DbSet<Post> Posts { get; set; }

    }
}