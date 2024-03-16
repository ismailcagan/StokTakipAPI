using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.Model.Dto.Response;
public class ProductResponseDto
{
    public Guid Id { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? ProductDescription { get; set; }
    public int Quantity { get; set; }
    //public int CategoryId { get; set; }
    public CategoryResponseDto Category { get; set; }
    //public virtual Category? Category { get; set; }

    //public int SupplierId { get; set; }
    public SupplierResponseDto Supplier { get; set; }
    //public virtual Supplier? Supplier { get; set; }
}
