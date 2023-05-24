using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SimpraApi.Persistance.SeedData;

namespace SimpraApi.Persistance.EntityFramework;
public class SimpraDbContext : DbContext
{
    private readonly IHttpContextAccessor? _contextAccessor;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Product> Category { get; set; } = null!;
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options) : base(options) { }
    public SimpraDbContext(DbContextOptions<SimpraDbContext> options, IHttpContextAccessor contextAccessor) : base(options) => _contextAccessor = contextAccessor;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        var seedData = DummyDataGenerator.GenerateDummyData(10, 50);
        modelBuilder.Entity<Category>().HasData(seedData["Category"]);
        modelBuilder.Entity<Product>().HasData(seedData["Product"]);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        var user = _contextAccessor?.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value ?? "admin";
        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added: SetAddedEntity(entry, user); break;
                case EntityState.Modified: SetModifiedEntity(entry, user); break;
                case EntityState.Deleted: SetDeletedEntity(entry, user); break;
            }
        }
    }

    private void SetDeletedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if (entry.Entity is not SoftDeletableEntity entity) return;
        entry.State = EntityState.Modified;
        entity.Status = Status.Deleted;
        entity.DeletedBy = user;
        entity.DeletedAt = DateTime.UtcNow;
    }

    private void SetModifiedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        if (entry.Entity is not AuditableEntity entity)
        {
            entry.State = EntityState.Detached;
            return;
        }
        entity.Status = Status.Updated;
        entity.UpdatedBy = user;
        entity.UpdatedAt = DateTime.UtcNow;
    }

    private void SetAddedEntity(EntityEntry<BaseEntity> entry, string user)
    {
        entry.Entity.Status = Status.Added;
        entry.Entity.CreatedBy = user;
        entry.Entity.CreatedAt = DateTime.UtcNow;
    }
}
