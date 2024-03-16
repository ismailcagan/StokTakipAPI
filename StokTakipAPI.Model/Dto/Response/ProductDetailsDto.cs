using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.Model.Dto.Response;
public class ProductDetailsDto
{
    public Guid Id { get; set; }
    public string? ProductName { get; set; }
    public decimal Price { get; set; }
    public string? ProductDescription { get; set; }
    public int Quantity { get; set; }
    public string? CategoryName { get; set; }
    public string? CompanyName { get; set; }
}
