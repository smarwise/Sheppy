using MunemoApp.Models.Domain;
using Microsoft.EntityFrameworkCore;
using MunemoApp.Models;

namespace MunemoApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<Users> users { get; set; }

        
    }
}
