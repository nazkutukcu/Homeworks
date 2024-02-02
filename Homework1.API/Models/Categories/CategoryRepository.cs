using Homework1.API.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Homework1.API.Models.Categories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;
        public Category Add(Category category)
        {
            _context.Categories.Add(category);
           // _context.SaveChanges();    => repository design patternda repositoryde hiçbir zaman SaveChange olmaz => unit of work uygulandı
            return category;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        //Eager Loading
        //Eager loading işlemlerini genellikle DbContext üzerinde gerçekleştirdim, çünkü DbContext veritabanı
        //bağlantısını yönetir.
        public List<Category> GetAllCategoriesWithProducts()
        {
            var categories = _context.Categories
                .Include(c => c.Products) // Eager Loading
                .ToList();

            return categories;
        }

        //Explicit Loading 
        public Category LoadProductWithCategory()
        {
            // Örnek bir kategori ID'si (1) ile kategori bulunur.   
            var category = _context.Categories.Find(1);
            // Entry metodu ile kategoriye ait ürünlerin koleksiyonunu al ve Load metodu ile explicit loading yap.
            _context.Entry(category).Collection(x => x.Products).Load();
            return category;

        }

    }
}
