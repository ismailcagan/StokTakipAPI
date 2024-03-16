using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.DataAccess.Context;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.DataAccess.Concrete;
public class CategoryRepository : BaseRepository<BaseDbContext, Category, int> ,ICategoryRepository
{
    public CategoryRepository(BaseDbContext context) : base(context)
    {
    }
}
