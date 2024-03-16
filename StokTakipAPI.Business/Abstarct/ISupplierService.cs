using Microsoft.EntityFrameworkCore.Query;
using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace StokTakipAPI.Business.Abstarct;
public interface ISupplierService
{
    ReturnModel<SupplierResponseDto> Add(SupplierCreateRequest request);
    ReturnModel<SupplierResponseDto> Delete(int id);
    ReturnModel<SupplierResponseDto> Update(SupplierUpdateRequest request);
    ReturnModel<SupplierResponseDto> GetById(int id);
    ReturnModel<List<SupplierResponseDto>> GetAll();
}
