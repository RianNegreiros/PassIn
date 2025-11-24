using Microsoft.EntityFrameworkCore;

using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure;

public class PassInDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<Attendee> Attendees { get; set; } = null!;
    public DbSet<CheckIn> CheckIns { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Database/PassInDb.db");
    }
}