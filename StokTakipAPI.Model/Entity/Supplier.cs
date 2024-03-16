namespace StokTakipAPI.Model.Entity;
public class Supplier : BaseEntity<int>
{
    public Supplier()
    {
        Products = new HashSet<Product>();
    }

    public string? CompanyName { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set;}
    public virtual ICollection<Product> Products { get; set; }
}
