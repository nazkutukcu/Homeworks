using Homework1.API.Models.ProductFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController(IProductFeatureService productFeatureService) : ControllerBase
    {
        private readonly IProductFeatureService _productFeatureService = productFeatureService;

        [HttpGet]
        public IActionResult GetAllProductsWithFeatures()
        {
            var allProductsWithFeatures = _productFeatureService.GetAllProductsWithFeatures();
            return Ok(allProductsWithFeatures);        
        }

        [HttpPost]
        public IActionResult AddProductAndProductFeature()
        {
            _productFeatureService.AddProductAndProductFeature();
            return Created();
        }

        [HttpGet("Explicit Loading Example")]
        public IActionResult LoadProductFeaturesForProduct()
        {
            var productFeature = _productFeatureService.LoadProductFeaturesForProduct();  //burada girilen product id'ye ait productfeature gelir.
            return Ok();
        }

    }
}
