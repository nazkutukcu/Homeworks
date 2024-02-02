namespace Homework1.API.Models.Categories
{
    public interface ICategoryRepository
    {
        Category Add(Category category);
        List<Category> GetAll();
        List<Category> GetAllCategoriesWithProducts();
        Category LoadProductWithCategory();
    }
}
