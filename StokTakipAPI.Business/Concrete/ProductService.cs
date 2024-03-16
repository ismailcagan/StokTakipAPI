using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.Business.Concrete;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IProductRules _productRules;

    public ProductService(IProductRepository productRepository, IMapper mapper, IProductRules productRules)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _productRules = productRules;
    }

    public ReturnModel<ProductResponseDto> Add(ProductCreateRequest request)
    {
        try
        {
            var product = _mapper.Map<Product>(request);
            _productRules.ProductNameMustBeUnique(product.ProductName);
            _productRepository.Add(product);
            var response = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>
            {
                Data = response,
                Message = "Product Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<ProductResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            };
        }
    }

    public ReturnModel<ProductResponseDto> Delete(Guid productId)
    {
        try
        {
            var product = _productRepository.GetByFilter(x => x.Id == productId);
            _productRules.ProductIdPresent(productId);
            _productRepository.Delete(product);
            var response = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>
            {
                Data = response,
                Message = $"{product.ProductName} adlı product silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<ProductResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<ProductResponseDto>> GetAll()
    {
        var products = _productRepository.GetAll(include: q => q.Include(p => p.Category).Include(p => p.Supplier));
        var response = _mapper.Map<List<ProductResponseDto>>(products);

        return new ReturnModel<List<ProductResponseDto>>
        {
            Data = response,
            Message = "Product Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<List<ProductResponseDto>> GetAllByPriceRange(decimal min, decimal max)
    {
        var products = _productRepository.GetAll(x => x.Price <= max && x.Price >= min);
        var repository = _mapper.Map<List<ProductResponseDto>>(products);
        return new ReturnModel<List<ProductResponseDto>>
        {
            Data = repository,
            Message = "Fiyat Aralığı Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<ProductDetailsDto> GetAllDetailId(Guid productId)
    {
        try
        {
            var product = _productRepository.GetProductDetails(productId);
            _productRules.ProductIdPresent(productId);
            return new ReturnModel<ProductDetailsDto>
            {
                Data = product,
                Message = $"Id si {productId} olan product Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<ProductDetailsDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
     
    }

    public ReturnModel<List<ProductDetailsDto>> GetAllDetailsCategoryId(int categoryId)
    {
        try
        {
            var productCategoryId = _productRepository.GetDetailsByCategoryId(categoryId);
            _productRules.CategoryIdPresent(categoryId);
            return new ReturnModel<List<ProductDetailsDto>>
            {
                Data = productCategoryId,
                Message = $"Category Id si {productCategoryId} olan ürünler Listelendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<List<ProductDetailsDto>>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
       
    }

    public ReturnModel<List<ProductDetailsDto>> GetByDetails()
    {
        var productDetail = _productRepository.GetAllroductsDetails();
        return new ReturnModel<List<ProductDetailsDto>>
        {
            Data = productDetail,
            Message = "Product Detayları Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<ProductResponseDto> GetById(Guid productId)
    {
        try
        {
            var product = _productRepository.GetByFilter(x => x.Id == productId);
            _productRules.ProductIdPresent(productId);
            var response = _mapper.Map<ProductResponseDto>(product);
            return new ReturnModel<ProductResponseDto>
            {
                Data = response,
                Message = "Product Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<ProductResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<ProductResponseDto> Update(ProductUpdateRequest request)
    {
        var product = _mapper.Map<Product>(request);
        _productRepository.Update(product);
        var response = _mapper.Map<ProductResponseDto>(product);
        return new ReturnModel<ProductResponseDto>
        {
            Data = response,
            Message = "Product Güncellendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }
}
