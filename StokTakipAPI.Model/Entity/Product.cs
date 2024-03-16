namespace StokTakipAPI.Model.Entity;
public class Product : BaseEntity<Guid>
{
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? ProductDescription { get; set;}
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
    public int SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }
}
