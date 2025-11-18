using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/Users/rian/Downloads/PassInDb.db");
    }
}