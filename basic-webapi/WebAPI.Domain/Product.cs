namespace WebAPI.Domain;

public class Product
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public int Stock { get; set; }
    public int Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
