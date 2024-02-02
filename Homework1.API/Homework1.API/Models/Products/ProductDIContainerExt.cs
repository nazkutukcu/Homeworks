using Homework1.API.Models.Categories;
using Homework1.API.Models.Definitions;
using Homework1.API.Models.ProductFeatures;

namespace Homework1.API.Models.Products
{
    public static class ProductDIContainerExt
    {
        public static void AddProductDIContainer(this IServiceCollection services)
        {
             services.AddScoped<IProductRepository, ProductRepositoryWithSqlServer>();
             services.AddScoped<IProductService, ProductServiceWithSqlServer>();
             services.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
             services.AddScoped<IProductFeatureService, ProductFeatureService>();
             services.AddScoped<IProductDefinitionRepository, ProductDefinitionRepository>();
            services.AddScoped<IProductDefinitionService, ProductDefinitionService>();
            //services.AddScoped<ProductHelper>();
        }
    }
}
