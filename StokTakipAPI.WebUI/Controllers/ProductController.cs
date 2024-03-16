using Microsoft.AspNetCore.Mvc;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Model.Dto.Request;

namespace StokTakipAPI.WebUI.Controllers;
public class ProductController : BaseController
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost("Product Ekle")]
    public IActionResult Add(ProductCreateRequest request)
    {
        var result = _productService.Add(request);
        return ActionResultInstance(result);
    }

    [HttpDelete("Product Sil")]
    public IActionResult Delete(Guid id)
    {
        var result = _productService.Delete(id);
        return ActionResultInstance(result);
    }

    [HttpPut("Product Güncelleme")]
    public IActionResult Update(ProductUpdateRequest request)
    {
        var result = _productService.Update(request);
        return ActionResultInstance(result);
    }

    [HttpPost("GetById")]
    public IActionResult GetById(Guid id)
    {
        var result = _productService.GetById(id);
        return ActionResultInstance(result);
    }

    [HttpGet("Product Listele")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        return ActionResultInstance(result);
    }

    [HttpPost("Fiyat Aralığına Göre Product Listele")]
    public IActionResult GetAllByPriceRange(decimal min, decimal max)
    {
        var result = _productService.GetAllByPriceRange(min,max);
        return ActionResultInstance(result);
    }

    [HttpPost("Product Id ye Göre Product Detay")]
    public IActionResult GetAllDetailId(Guid id)
    {
        var result = _productService.GetAllDetailId(id);
        return ActionResultInstance(result);
    }

    [HttpGet("Product Detayları Listele")]
    public IActionResult GetByDetails()
    {
        var result = _productService.GetByDetails();
        return ActionResultInstance(result);
    }

    [HttpPost("Category Id ye Göre Product Listele")]
    public IActionResult GetAllDetailsCategoryId(int categoryId)
    {
        var result = _productService.GetAllDetailsCategoryId(categoryId);
        return ActionResultInstance(result);
    }
}
