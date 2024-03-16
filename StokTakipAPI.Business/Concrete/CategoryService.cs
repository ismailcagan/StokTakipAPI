using AutoMapper;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.Exceptions;
using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.Business.Concrete;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryRules _categoryRules;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, ICategoryRules categoryRules, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _categoryRules = categoryRules;
        _mapper = mapper;
    }

    public ReturnModel<CategoryResponseDto> Add(CategoryCreateRequest request)
    {
        try
        {
            Category response = _mapper.Map<Category>(request);
            _categoryRules.CategotyNameMustBeUnique(response.CategoryName);
            _categoryRepository.Add(response);
            CategoryResponseDto responseDto = _mapper.Map<CategoryResponseDto>(response);
            return new ReturnModel<CategoryResponseDto>
            {
                Data = responseDto,
                Message = "Category Eklendi",
                StatusCode = System.Net.HttpStatusCode.Created
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.NotFound
            };
        }
    }

    public ReturnModel<CategoryResponseDto> Delete(int id)
    {
        try
        {
            Category category = _categoryRepository.GetByFilter(X=>X.Id==id);
            _categoryRules.CategoryIdPresent(category.Id);
            _categoryRepository.Delete(category);
            CategoryResponseDto responseDto = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>
            {
                Data = responseDto,
                Message = "Category Silindi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }

    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        var category = _categoryRepository.GetAll();
        List<CategoryResponseDto> responseDto = _mapper.Map<List<CategoryResponseDto>>(category);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = responseDto,
            Message = "Categoryler Listelendi",
            StatusCode = System.Net.HttpStatusCode.OK
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
        try
        {
            Category category = _categoryRepository.GetByFilter(X => X.Id == id);
            _categoryRules.CategoryIdPresent(id);
            CategoryResponseDto responseDto = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>
            {
                Data = responseDto,
                Message = "Category Getirildi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
    }

    public ReturnModel<CategoryResponseDto> Update(CategoryUpdateRequest request)
    {
        try
        {
            var category = _mapper.Map<Category>(request);
            _categoryRules.CategoryIdPresent(category.Id);
            _categoryRules.CategotyNameMustBeUnique(category.CategoryName);
            _categoryRepository.Update(category);

            var response = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>
            {
                Data = response,
                Message = "Category Güncellendi",
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
        catch (BusinessException ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Message = ex.Message,
                StatusCode = System.Net.HttpStatusCode.BadRequest
            };
        }
       
    }
}
