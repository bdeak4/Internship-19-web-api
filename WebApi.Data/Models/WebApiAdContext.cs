using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models.Entities;

namespace WebApi.Data.Models;

public class WebApiAdContext : DbContext
{
    public WebApiAdContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Ad> Ads { get; set; }
    public DbSet<AdOwner> AdOwners { get; set; }
    public DbSet<AdCategory> AdCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<AdOwner>()
            .HasIndex(o => o.Email)
            .IsUnique();
    }
}