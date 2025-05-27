using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProducts([FromBody] Product product)
        {
            try
            {
                return Ok(await _productService.AddProduct(product));
            }
            catch
            {
                throw;
            }            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducts(Guid id, [FromBody] Product product)
        {
            return Ok(await _productService.UpdateProduct(id, product));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FetchProducts(Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<int> YieldExample()
        {
            return getPoints();
        }

        private IEnumerable<int> getPoints()
        {
            for (int i = 0; i <= 9; i++)
            {
                yield return i;
            }
        }
    }
}
