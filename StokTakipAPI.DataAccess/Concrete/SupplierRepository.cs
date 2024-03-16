using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.DataAccess.Context;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.DataAccess.Concrete;
public class SupplierRepository : BaseRepository<BaseDbContext, Supplier, int>, ISupplierRepository
{
    public SupplierRepository(BaseDbContext context) : base(context)
    {
    }
}
