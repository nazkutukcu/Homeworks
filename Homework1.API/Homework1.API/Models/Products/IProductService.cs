using Homework1.API.Models.DTOs;

namespace Homework1.API.Models.Products
{
    public interface IProductService
    {
        ResponseDto<List<ProductDto>> GetAll();
        ProductDto GetById(int id);
        void Delete(int id);
        ResponseDto<int> Add(ProductAddDtoRequest request);
        void Update(ProductUpdateDtoRequest request);
    }
}
