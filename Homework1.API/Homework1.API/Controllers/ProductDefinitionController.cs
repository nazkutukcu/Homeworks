using Homework1.API.Models.Definitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDefinitionController(IProductDefinitionService productDefinitionService) : ControllerBase
    {
        private IProductDefinitionService _productDefinitionService = productDefinitionService;
        [HttpPost]
        public IActionResult AddProductAndProductDefinition()
        {
            _productDefinitionService.AddProductAndProductDefinition();
            return Created();
        }
    }
}
