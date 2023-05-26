namespace SimpraApi.Persistance.EntityFramework;

public class SoftDeletableEntityConfiguration<TEntity> : AuditableEntityConfiguration<TEntity> where TEntity : SoftDeletableEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.DeletedBy).HasMaxLength(36).IsRequired(false);
    }
}
