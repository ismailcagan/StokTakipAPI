using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.DataAccess.Abstract;

namespace StokTakipAPI.Business.BusinessRules.Concrete;
public class ProductRules : IProductRules
{
    private readonly IProductRepository _productRepository;

    public ProductRules(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void CategoryIdPresent(int categoryId)
    {
        var producttoCategoryId = _productRepository.GetByFilter(x=>x.CategoryId == categoryId);
        if(producttoCategoryId is null)
        {
            throw new BusinessException($"{categoryId} category Idsine ait bilgi bulunamadı");
        }
    }

    public void ProductIdPresent(Guid id)
    {
        var productIdUniq = _productRepository.GetByFilter(x=>x.Id == id);
        if(productIdUniq is null)
        {
            throw new BusinessException($"{id} id sine ait bilgi bulunamadı");
        }
    }

    public void ProductNameMustBeUnique(string productName)
    {
        var productNameUniq = _productRepository.GetByFilter(x=>x.ProductName== productName);
        if(productNameUniq is not null)
        {
            throw new BusinessException($"{productName} adlı product mevcut");
        }
    }
}
