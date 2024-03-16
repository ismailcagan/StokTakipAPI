using Microsoft.AspNetCore.Mvc;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Model.Dto.Request;

namespace StokTakipAPI.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Category Ekle")]
        public IActionResult Add([FromForm]CategoryCreateRequest request)
        {
            var result = _categoryService.Add(request);
           return ActionResultInstance(result);
        }

        [HttpDelete("Category Sil")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            return ActionResultInstance(result);
        }

        [HttpPut("Category Güncelle")]
        public IActionResult Update([FromForm]CategoryUpdateRequest request)
        {
            var result = _categoryService.Update(request);
            return ActionResultInstance(result);
        }

        [HttpGet("Category Getir")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            return ActionResultInstance(result);
        }

        [HttpGet("Category Listele")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return ActionResultInstance(result);
        }
    }
}
