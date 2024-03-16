namespace StokTakipAPI.Business.BusinessRules.Abstract;
public interface IProductRules
{
    void ProductNameMustBeUnique(string productName);
    void ProductIdPresent(Guid id);
    void CategoryIdPresent(int categoryId);
}
