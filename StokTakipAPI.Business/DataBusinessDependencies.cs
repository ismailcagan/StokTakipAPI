using Microsoft.Extensions.DependencyInjection;
using StokTakipAPI.Business.Abstarct;
using StokTakipAPI.Business.BusinessRules.Abstract;
using StokTakipAPI.Business.BusinessRules.Concrete;
using StokTakipAPI.Business.Concrete;
using System.Reflection;

namespace StokTakipAPI.Business;
public static class DataBusinessDependencies
{
    public static IServiceCollection AddDataBusinessDependencies(this IServiceCollection services)
    {
        services.AddScoped<ISupplierService, SupplierService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddScoped<ICategoryRules, CategoryRules>();
        services.AddScoped<ISupplierRules, SupplierRules>();
        services.AddScoped<IProductRules, ProductRules>();

        return services;
    }
}
