namespace StokTakipAPI.Business.BusinessRules.Abstract;
public interface ICategoryRules
{
    void CategotyNameMustBeUnique(string categoryName);
    void CategoryIdPresent(int id);
}
