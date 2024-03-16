using AutoMapper;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.WebUI.Profiles;
public class Mapping : Profile
{
    public Mapping()
    {
        // Category
        CreateMap<CategoryCreateRequest, Category>().ReverseMap();
        CreateMap<CategoryUpdateRequest, Category>().ReverseMap();
        CreateMap<Category,CategoryResponseDto>().ReverseMap();

        // Supplier
        CreateMap<SupplierCreateRequest, Supplier>().ReverseMap();
        CreateMap<SupplierUpdateRequest, Supplier>().ReverseMap();
        CreateMap<Supplier, SupplierResponseDto>().ReverseMap();

        // Product
        CreateMap<ProductCreateRequest, Product>().ReverseMap();
        CreateMap<ProductUpdateRequest,Product>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();
    }
}
