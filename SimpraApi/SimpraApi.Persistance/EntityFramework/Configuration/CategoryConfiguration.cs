namespace SimpraApi.Persistance.EntityFramework;

public class CategoryConfiguration : SoftDeletableEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(30);

        builder.HasIndex(x => x.Name).IsUnique(true);

        builder.HasMany(x=>x.Products).WithOne(x => x.Category).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict);
    }
}
