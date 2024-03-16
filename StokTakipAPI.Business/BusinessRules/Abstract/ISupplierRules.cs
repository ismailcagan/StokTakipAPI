namespace StokTakipAPI.Business.BusinessRules.Abstract;
public interface ISupplierRules
{
    void SupplierNameMustBeUnique(string companyName);
    void SupplierPhoneMustBeUnique(string phone);
    void SupplierEmailMustBeUnique(string email);
    void SupplierIdPresent(int id);
}
