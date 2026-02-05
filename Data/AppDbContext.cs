using Microsoft.EntityFrameworkCore;
using InterviewBKO.Models;

namespace InterviewBKO.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Facility> Facilities { get; set; }
    public DbSet<User> Users { get; set; } = null!;

}