using Homework1.API.Models.Products;

namespace Homework1.API.Models.ProductFeatures
{
    public interface IProductFeatureRepository
    {
        List<Product> GetAllProductsWithFeatures();
        ProductFeature Add(ProductFeature productFeature);
        ProductFeature LoadProductFeaturesForProduct();
    }
}
