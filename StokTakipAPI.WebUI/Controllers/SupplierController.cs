using Microsoft.AspNetCore.Mvc;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Model.Dto.Request;

namespace StokTakipAPI.WebUI.Controllers;
public class SupplierController : BaseController
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost("Supplier Ekle")]
    public IActionResult Add([FromForm]SupplierCreateRequest request)
    {
        var result = _supplierService.Add(request);
        return ActionResultInstance(result);
    }

    [HttpDelete("Supplier Sil")]
    public IActionResult Delete([FromForm]int id)
    {
        var result = _supplierService.Delete(id);
        return ActionResultInstance(result);
    }

    [HttpPut("Supplier Güncelle")]
    public IActionResult Update([FromForm] SupplierUpdateRequest request)
    {
        var result = _supplierService.Update(request);
        return ActionResultInstance(result);
    }

    [HttpPost("Supplier Getir")]
    public IActionResult GetById([FromForm] int id)
    {
        var result = _supplierService.GetById(id);
        return ActionResultInstance(result);
    }

    [HttpGet("Supplier Listele")]
    public IActionResult GetAll()
    {
        var result = _supplierService.GetAll();
        return ActionResultInstance(result);
    }
}
