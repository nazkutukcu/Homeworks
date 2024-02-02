using Homework1.API.Models.Categories;
using Homework1.API.Models.DTOs;
using Homework1.API.Models.Products;
using Homework1.API.Models.UnitOfWorks;

namespace Homework1.API.Models.Definitions
{
    public class ProductDefinitionService(IUnitOfWork unitOfWork, IProductRepository productRepository, IProductDefinitionRepository productDefinitionRepository) : IProductDefinitionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductDefinitionRepository _productDefinitionRepository = productDefinitionRepository;
        public void AddProductAndProductDefinition() 
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                var product = new Product
                {
                    Name = "Bant 2",
                    Price = 100,
                    Description = "Bant 2 Description",
                    CategoryId = 2
                };
                _productRepository.Add(product);                                         
                _unitOfWork.Commit();

                var productDefinition = new ProductDefinition
                {
                    ProductId = product.Id,
                    StockCount = 100,
                };

                _productDefinitionRepository.Save(productDefinition); 

                _unitOfWork.Commit();
                transaction.Commit();
            }

        }
    }
}
