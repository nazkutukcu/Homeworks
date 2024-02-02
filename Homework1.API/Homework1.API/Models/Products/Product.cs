using Homework1.API.Models.Categories;
using Homework1.API.Models.ProductFeatures;

namespace Homework1.API.Models.Products
{
    //entity class => veritabanındaki product tablosu karşılığı var.
    public class Product
    {
        public int Id { get; set; } // Bu özellik otomatik olarak artan bir kimlik sütunudur.
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = default!;
        public int CategoryId { get; set; }  //FK - Foreign Key : Product,Category tablosuna bağlı
                                             
        //Navigation Property - bir entityden başka bir entitye referans : bir data kaydederken doldurmama gerek yok.
        public Category? Category { get; set; }

        //Navigation Property
        public ProductFeature ProductFeatures { get; set; }
    }
}
