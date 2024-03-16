using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.DataAccess.Abstract;

namespace StokTakipAPI.Business.BusinessRules.Concrete;
public class SupplierRules : ISupplierRules
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierRules(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public void SupplierIdPresent(int id)
    {
        var supplierId = _supplierRepository.GetByFilter(x => x.Id == id);
        if(supplierId is null)
        {
            throw new BusinessException($"{id} id sine ait veri bulunamadı");
        }
    }

    public void SupplierEmailMustBeUnique(string email)
    {
        var supplierEmail = _supplierRepository.GetByFilter(x=>x.Email == email);
        if(supplierEmail is not null)
        {
            throw new BusinessException($"{email} email adresi veri tabanında mevcuttur");
        }
    }

    public void SupplierNameMustBeUnique(string companyName)
    {
        var supplierCompanyName = _supplierRepository.GetByFilter(x=>x.CompanyName == companyName);
        if(supplierCompanyName is not null)
        {
            throw new BusinessException($"{companyName} adlı şirket kayıtlarda mevcuttur");
        }
    }

    public void SupplierPhoneMustBeUnique(string phone)
    {
        var supplierPhone = _supplierRepository.GetByFilter(x=> x.Phone == phone);
        if(supplierPhone is not null)
        {
            throw new BusinessException($"{phone} telefon numarası mevcuttur");
        }
    }
}
