using Homework1.API.Models.Categories;
using Homework1.API.Models.Products;
using Homework1.API.Models.UnitOfWorks;

namespace Homework1.API.Models.ProductFeatures
{
    public class ProductFeatureService(IProductFeatureRepository productFeatureRepository, IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductFeatureService
    {
        private readonly IProductFeatureRepository _productFeatureRepository = productFeatureRepository;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        //unit of work kullanılmıştır.
        ///Belirli bir product ve bu product'a ait productfeature eklenir.
        public void AddProductAndProductFeature()
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                // Product eklemek
                var product = new Product
                {
                    Name = "Bant Yeni",
                    Price = 100,
                    Description = "Bant Yeni Description",
                    CategoryId = 1
                };
                _productRepository.Add(product);
                _unitOfWork.Commit();

                // Eklenen ürüne ait özellik eklemek
                var productFeature = new ProductFeature
                {
                    ProductId = product.Id,
                    Width = 100,
                    Color ="Pink",
                    Height = 100,
                };
                _productFeatureRepository.Add(productFeature);

                _unitOfWork.Commit();
                transaction.Commit();
            }
        }

        // Tüm ürünlerin ProductFeatures özelliklerini getirir.
        public List<Product> GetAllProductsWithFeatures()
        {
            return _productFeatureRepository.GetAllProductsWithFeatures();
        }

        ///Belirli bir product ID'sine sahip productı bulur ve bu producta ait productfeature yükler.
        public ProductFeature LoadProductFeaturesForProduct()
        {
            return _productFeatureRepository.LoadProductFeaturesForProduct();
        }
    }
}
