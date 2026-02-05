using Microsoft.EntityFrameworkCore;
using InterviewBKO.Core.Entities;

namespace InterviewBKO.Infrastructure.Data;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Facility> Facilities { get; set; }
    public DbSet<User> Users { get; set; } = null!;

}