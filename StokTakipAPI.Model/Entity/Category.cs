namespace StokTakipAPI.Model.Entity;
public class Category : BaseEntity<int>
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public string? CategoryName { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
