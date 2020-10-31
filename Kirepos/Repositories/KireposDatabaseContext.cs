using System.Threading;
using System.Threading.Tasks;
using Kirepos.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Kirepos.Repositories
{
    public class KireposDatabaseContext : DbContext
    {
        public KireposDatabaseContext(DbContextOptions options)  : base(options)
        {
            
        }

        public DbSet<Report> Reports { get; set; }
    }
}
