using Homework1.API.Models.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;

        [HttpPost]
        public IActionResult AddCategoryAndProduct()
        {
            _categoryService.AddCategoryAndProduct();
            return Created();
        }

        [HttpGet]
        public IActionResult GetAllCategoriesWithProducts()
        {
            var allCategories = _categoryService.GetAllCategoriesWithProducts();
            return Ok(); //buraya debug atarak baktığımızda bütün kategoriler ve bu kategorilere ait product'ları dolu bir şekilde görebiliyoruz.
        }

        [HttpGet("Explicit Loading Example")]
        public IActionResult LoadProductWithCategory()
        {
            var category = _categoryService.LoadProductWithCategory();  
            return Ok();
        }
        

        
    }
}
