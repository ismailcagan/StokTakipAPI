using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;

namespace StokTakipAPI.Business.Abstarct;
public interface IProductService
{
    ReturnModel<ProductResponseDto> Add(ProductCreateRequest request);
    ReturnModel<ProductResponseDto> Update(ProductUpdateRequest request);
    ReturnModel<ProductResponseDto> Delete(Guid productId);
    ReturnModel<ProductResponseDto> GetById(Guid productId);
    ReturnModel<List<ProductResponseDto>> GetAll();
    ReturnModel<List<ProductResponseDto>> GetAllByPriceRange(decimal min, decimal max);
    ReturnModel<ProductDetailsDto> GetAllDetailId(Guid productId);
    ReturnModel<List<ProductDetailsDto>> GetByDetails();
    ReturnModel<List<ProductDetailsDto>> GetAllDetailsCategoryId(int categoryId);
}
