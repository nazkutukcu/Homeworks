using Homework1.API.Models.Products;

namespace Homework1.API.Models.ProductFeatures
{

    // ProductFeature sınıfı, bir ürün ile ilişkili özellikleri temsil eder.
    // Bire-bir ilişki kurulur; her ProductFeature nesnesi yalnızca bir Product nesnesine aittir.
    public class ProductFeature
    {
        public int Id { get; set; }
        public int Height { get; set; } = default!;
        public int Width { get; set; } = default!;
        public string Color { get; set; } = default!;

        // Foreign Key (Dış Anahtar): Her bir ProductFeature nesnesinin bir Product'a ait olması için kullanılır.
        public int ProductId { get; set; } //FK

        // Navigation Property (Gezinme Özelliği): Product ile ilişkiyi temsil eder.
        // Bu özellik, ORM (Object-Relational Mapper) tarafından ilişkiyi yönetmek için kullanılır.
        public Product Product { get; set; } = default!;
    }
}
