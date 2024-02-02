using Homework1.API.Models.Products;
using Homework1.API.Models.UnitOfWorks;

namespace Homework1.API.Models.Categories
{
    public class CategoryService(IProductRepository productRepository,ICategoryRepository categoryRepository,IUnitOfWork unitOfWork) : ICategoryService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        //unit of work kullanılmıştır.
        ///Belirli bir kategori ve bu kategoriye ait bir ürünü ekler.
        public void AddCategoryAndProduct()
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                // Kategori eklemek
                var category = new Category
                {
                    Name = "Bantlar"
                };
                _categoryRepository.Add(category);
                _unitOfWork.Commit();

                // Eklenen kategoriye ait ürün eklemek
                var product = new Product
                {
                    Name = "Bant 1",
                    Price = 100,
                    Description = "Bant 1 Description",
                    CategoryId = category.Id // Yukarıda eklenen kategori ID'si
                };
                _productRepository.Add(product);

                _unitOfWork.Commit();
                transaction.Commit();
            }   
        }

        ///Tüm kategorileri ve bu kategorilere ait ürünleri getirir.
        public List<Category> GetAllCategoriesWithProducts()
        {
            return _categoryRepository.GetAllCategoriesWithProducts();
        }

        ///Belirli bir kategori ID'sine sahip kategoriyi bulur ve bu kategoriye ait ürünleri yükler.
        public Category LoadProductWithCategory()
        {
            return _categoryRepository.LoadProductWithCategory();
        }


    }
}

