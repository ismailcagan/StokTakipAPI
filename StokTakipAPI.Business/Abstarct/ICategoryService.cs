using StokTakipAPI.Business.ReturnModels;
using StokTakipAPI.Model.Dto.Request;
using StokTakipAPI.Model.Dto.Response;

namespace StokTakipAPI.Business.Abstarct;
public interface ICategoryService
{
    ReturnModel<CategoryResponseDto> Add(CategoryCreateRequest request);
    ReturnModel<CategoryResponseDto> Delete(int id);
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> Update(CategoryUpdateRequest request);
    /*
    void Delete(TEntity entity);
    void Update(TEntity entity);
    TEntity GetById(TId id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    TEntity GetByFilter(Expression<Func<TEntity, bool>> filter,
                               Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null!,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    */
}
