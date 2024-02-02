namespace Homework1.API.Models.Definitions
{
    public class ProductDefinitionRepository(AppDbContext context) :IProductDefinitionRepository
    {
        private readonly AppDbContext _context = context;

        public ProductDefinition Save(ProductDefinition productDefinition)
        {
            _context.ProductDefinitions.Add(productDefinition);
            // _context.SaveChanges(); 
            return productDefinition;
        }
    }
}
