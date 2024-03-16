using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.DataAccess.Abstract;
public interface IProductRepository : IBaseRepository<Product,Guid>
{
    List<ProductDetailsDto> GetAllroductsDetails();
    List<ProductDetailsDto> GetDetailsByCategoryId(int categoryId);
    ProductDetailsDto GetProductDetails(Guid productId);
}
