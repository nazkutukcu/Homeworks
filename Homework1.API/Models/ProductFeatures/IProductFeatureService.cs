using Homework1.API.Models.Products;

namespace Homework1.API.Models.ProductFeatures
{
    public interface IProductFeatureService
    {
        List<Product> GetAllProductsWithFeatures();
        void AddProductAndProductFeature();
        ProductFeature LoadProductFeaturesForProduct();
    }
}
