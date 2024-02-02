using Homework1.API.Models.DTOs;

namespace Homework1.API.Models.Products
{
    public class ProductServiceWithSqlServer : IProductService
    {
        public ResponseDto<int> Add(ProductAddDtoRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ResponseDto<List<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductUpdateDtoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
