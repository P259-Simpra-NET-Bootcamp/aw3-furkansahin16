namespace SimpraApi.Domain;

[Table("Product", Schema = "dbo")]
public class Product : SoftDeletableEntity
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Tag { get; set; } = null!;

    //Navigation Properties
    public virtual Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
}