namespace WebAPI.Domain;

public class Category
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        Products = new HashSet<Product>();
    }
}
