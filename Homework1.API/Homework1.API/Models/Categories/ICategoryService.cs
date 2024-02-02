namespace Homework1.API.Models.Categories
{
    public interface ICategoryService
    {
        void AddCategoryAndProduct();
        List<Category> GetAllCategoriesWithProducts();
        Category LoadProductWithCategory();
    }
}
