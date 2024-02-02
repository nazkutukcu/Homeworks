
namespace Homework1.API.Models.Products
{
    public class ProductRepositoryWithSqlServer(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;
        public Product Add(Product product)
        {
            _context.Products.Add(product);
            //_context.SaveChanges(); 
            return product;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
