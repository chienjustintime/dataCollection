using SP.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SP.Domain.Entity;

namespace SP.Application
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync();
    }
}

