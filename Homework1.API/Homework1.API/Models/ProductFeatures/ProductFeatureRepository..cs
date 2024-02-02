using Homework1.API.Models.Categories;
using Homework1.API.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Homework1.API.Models.ProductFeatures
{
    public class ProductFeatureRepository(AppDbContext context) : IProductFeatureRepository
    {
        private readonly AppDbContext _context = context;

        //Eager Loading
        // Tüm ürünlerin ProductFeatures özelliklerini yükler
        public List<Product> GetAllProductsWithFeatures()
        {
            var productsWithFeatures = _context.Products
                .Include(p => p.ProductFeatures) 
                .ToList();

            return productsWithFeatures;
        }

        public ProductFeature Add(ProductFeature productFeature)
        {
            _context.ProductFeatures.Add(productFeature);
            // _context.SaveChanges();    => repository design patternda repositoryde hiçbir zaman SaveChange olmaz => unit of work uygulandı
            return productFeature;
        }

        //Explicit Loading 
        //Belirli bir ürüne ait ProductFeature'ları Explicit Loading ile yükler.
        public ProductFeature LoadProductFeaturesForProduct()
        {
            // Örnek bir product ID'si (6) ile kategori bulunur.   
            var product = _context.Products.Find(6);
            // Entry metodu ile ürüne ait ProductFeature özelliğini al ve Load metodu ile explicit loading yap.
            _context.Entry(product).Reference(x => x.ProductFeatures).Load();

            return product.ProductFeatures;

              // Product ve ProductFeature arasında birbirine karşılık gelen bir ilişki (1'e 1 ilişki) varsa,
              // bu durumda Collection kullanmak hata almaya neden olabilir. Çünkü Collection genellikle 1'den çok ilişkilere
              // (1-N ilişkileri) uygundur.
              //Bu durumda, Reference kullanarak bir ProductFeature'ı belirli bir Product için yükleyebiliriz.
        }

    }
}
