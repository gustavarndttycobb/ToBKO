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

    public DbSet<Equipment> Equipments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Equipment>()
            .HasOne(e => e.Facility)
            .WithMany(f => f.Equipments)
            .HasForeignKey(e => e.FacilityId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Facility>()
            .HasOne(f => f.Parent)
            .WithMany(f => f.Children)
            .HasForeignKey(f => f.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}