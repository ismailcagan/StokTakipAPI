using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.DataAccess.Abstract;

namespace StokTakipAPI.Business.BusinessRules.Concrete;
public class CategoryRules : ICategoryRules
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryRules(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CategotyNameMustBeUnique(string categoryName)
    {
        var category = _categoryRepository.GetByFilter(x => x.CategoryName == categoryName);
        if (category is not null)
        {
            throw new BusinessException($"{categoryName} adlı category mevcut lütfen farklı bir category Ekleyin");
        }
    }
    public void CategoryIdPresent(int id)
    {
        var category = _categoryRepository.GetByFilter(x => x.Id == id);
        if (category is null)
        {
            throw new BusinessException($"{id} id ye ait category bulunamadı");
        }
    }
}
