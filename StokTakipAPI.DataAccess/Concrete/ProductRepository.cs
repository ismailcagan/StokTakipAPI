using Microsoft.EntityFrameworkCore;
using StokTakipAPI.DataAccess.Abstract;
using StokTakipAPI.DataAccess.Context;
using StokTakipAPI.Model.Dto.Response;
using StokTakipAPI.Model.Entity;

namespace StokTakipAPI.DataAccess.Concrete;
public class ProductRepository : BaseRepository<BaseDbContext, Product, Guid>, IProductRepository
{
    public ProductRepository(BaseDbContext context) : base(context)
    {
    }

    public List<ProductDetailsDto> GetAllroductsDetails()
    {

        var birlesmisTablolar = Context.Products.Join(Context.Categories,
           p => p.CategoryId,
           c => c.Id,
           (product, category) => new { product, category })
            .Join(Context.Suppliers,
           combined => combined.product.SupplierId,
           supplier => supplier.Id,
           (combined, supplier) => new ProductDetailsDto
           {
               Id = combined.product.Id,
               ProductName = combined.product.ProductName,
               Price = combined.product.Price,
               ProductDescription = combined.product.ProductDescription,
               Quantity = combined.product.Quantity,
               CategoryName = combined.category.CategoryName,
               CompanyName = supplier.CompanyName
           })
     .ToList();

        return birlesmisTablolar;
    }

    public List<ProductDetailsDto> GetDetailsByCategoryId(int categoryId)
    {
        var birlesmisTablolar = Context.Products.Where(x=>x.CategoryId==categoryId).Join(Context.Categories,
          p => p.CategoryId,
          c => c.Id,
          (product, category) => new { product, category })
           .Join(Context.Suppliers,
          combined => combined.product.SupplierId,
          supplier => supplier.Id,
          (combined, supplier) => new ProductDetailsDto
          {
              Id = combined.product.Id,
              ProductName = combined.product.ProductName,
              Price = combined.product.Price,
              ProductDescription = combined.product.ProductDescription,
              Quantity = combined.product.Quantity,
              CategoryName = combined.category.CategoryName,
              CompanyName = supplier.CompanyName
          })
    .ToList();

        return birlesmisTablolar;
    }

    public ProductDetailsDto GetProductDetails(Guid productId)
    {
        var birlesmisTablolar = Context.Products.Where(x=>x.Id==productId).Join(Context.Categories,
         p => p.CategoryId,
         c => c.Id,
         (product, category) => new { product, category })
          .Join(Context.Suppliers,
         combined => combined.product.SupplierId,
         supplier => supplier.Id,
         (combined, supplier) => new ProductDetailsDto
         {
             ProductName = combined.product.ProductName,
             Price = combined.product.Price,
             ProductDescription = combined.product.ProductDescription,
             Quantity = combined.product.Quantity,
             CategoryName = combined.category.CategoryName,
             CompanyName = supplier.CompanyName
         }).FirstOrDefault();
   

        return birlesmisTablolar;
    }
}
