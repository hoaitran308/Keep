using Keep.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Keep.API.Data
{
    public class KeepDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public KeepDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
