using Homework1.API.Models.Products;

namespace Homework1.API.Models.Categories
{
    //Bu entity product'lara bağlı olucak.
    //her product'ın bir kategorisi olucak.
    //1 category birden fazla product'ı olabilsin.Kimse kategorisi belirtilmeden product ekleyemesin.
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public List<Product>? Products { get; set; }  //null gelebilir.
    }
}
