namespace Zentrack.Api.Data;

using Microsoft.EntityFrameworkCore;
using Zentrack.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
}
