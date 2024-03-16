using AutoMapper;
using Azure;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.Business.Concrete;
public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private IMapper _mapper;
    private readonly ISupplierRules _supplierRules;
    public SupplierService(ISupplierRepository supplierRepository, IMapper mapper, ISupplierRules supplierRules)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
        _supplierRules = supplierRules;
    }

    public ReturnModel<SupplierResponseDto> Add(SupplierCreateRequest request)
    {
        try
        {
            var supplier = _mapper.Map<Supplier>(request);
            _supplierRules.SupplierNameMustBeUnique(supplier.CompanyName);
            _supplierRules.SupplierPhoneMustBeUnique(supplier.Phone);
            _supplierRules.SupplierEmailMustBeUnique(supplier.Email);
            _supplierRepository.Add(supplier);

            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return new ReturnModel<SupplierResponseDto>
            {
                Data = response,
                Message = "Supplier Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created,
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<SupplierResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
            };
        }
    }

    public ReturnModel<SupplierResponseDto> Delete(int id)
    {
        try
        {
            _supplierRules.SupplierIdPresent(id);
            var supplier = _supplierRepository.GetByFilter(x => x.Id == id);
            _supplierRepository.Delete(supplier);
            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return new ReturnModel<SupplierResponseDto>
            {
                Data = response,
                Message = "Supplier Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };

        }
        catch (BusinessException ex)
        {
            return new ReturnModel<SupplierResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<SupplierResponseDto> Update(SupplierUpdateRequest request)
    {
        var supplier = _mapper.Map<Supplier>(request);
        _supplierRepository.Update(supplier);
        var response = _mapper.Map<SupplierResponseDto>(supplier);
        return new ReturnModel<SupplierResponseDto>
        {
            Data = response,
            Message = "Supplier Güncellendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<SupplierResponseDto> GetById(int id)
    {
        try
        {
            _supplierRules.SupplierIdPresent(id);
            var supplier = _supplierRepository.GetByFilter(x=>x.Id==id);
            var response = _mapper.Map<SupplierResponseDto>(supplier);
            return new ReturnModel<SupplierResponseDto>
            {
                Data = response,
                Message = "Supplier Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<SupplierResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<List<SupplierResponseDto>> GetAll()
    {
        var suppliers = _supplierRepository.GetAll();
        var response = _mapper.Map<List<SupplierResponseDto>>(suppliers);
        return new ReturnModel<List<SupplierResponseDto>>
        {
            Data = response,
            Message = "Supplier Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK,
        };
    }
}
