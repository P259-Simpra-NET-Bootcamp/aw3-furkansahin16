using System.Security.Cryptography.X509Certificates;

namespace SimpraApi.Persistance.EntityFramework;

public class ProductConfiguration : SoftDeletableEntityConfiguration<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Url).IsRequired(true).HasMaxLength(30);
        builder.Property(x => x.Tag).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.CategoryId).IsRequired(true);

        builder.HasIndex(x => x.Name).IsUnique(true);

        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
