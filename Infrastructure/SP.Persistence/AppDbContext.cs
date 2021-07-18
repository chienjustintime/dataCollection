using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SP.Application;
using SP.Domain.Entity;

namespace SP.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
