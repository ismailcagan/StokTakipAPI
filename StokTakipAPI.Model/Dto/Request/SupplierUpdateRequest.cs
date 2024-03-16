namespace StokTakipAPI.Model.Dto.Request;
public class SupplierUpdateRequest
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? City { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}
