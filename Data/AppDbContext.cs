using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Facility> Facilities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Facility>().HasData(
            new Facility
            {
                Id = 1,
                Name = "Main Compressor",
                IsWorking = true,
                TimeRunning = DateTime.Now.AddHours(-8)
            },
            new Facility
            {
                Id = 2,
                Name = "Hydraulic Pump",
                IsWorking = false,
                TimeRunning = DateTime.Now.AddDays(-2)
            },
            new Facility
            {
                Id = 3,
                Name = "Emergency Generator",
                IsWorking = true,
                TimeRunning = DateTime.Now.AddHours(-24)
            }
        );
    }
}