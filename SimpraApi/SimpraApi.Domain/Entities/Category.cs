namespace SimpraApi.Domain;

[Table("Category", Schema = "dbo")]
public class Category : SoftDeletableEntity
{
    public string Name { get; set; } = null!;

    //Navigation Properties
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}