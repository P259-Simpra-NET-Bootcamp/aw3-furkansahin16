namespace SimpraApi.Persistance.EntityFramework;
public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.Id).IsRequired(true);
        builder.Property(x => x.Status).IsRequired(true);
        builder.Property(x => x.CreatedBy).HasMaxLength(36).IsRequired(false);

        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();
    }
}