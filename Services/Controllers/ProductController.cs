using Mango.Services.ProductAPI.AppServices;
using Mango.Services.ProductAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataServices service;

        public ProductController(DataServices service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var expensive = HttpContext.Request.Query["expensive"].ToString();

            if (bool.TryParse(expensive, out bool ex) && bool.Parse(expensive))
            {
                return await service.GetExpensiveProducts();
            }
            return await service.GetProducts();
        }


        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product product)
        {
            await service.Create(product);

            return Ok();
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Product>> Update(string id, Product updatedProduct)
        {
            var product = await service.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            await service.Update(id, updatedProduct);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult<Product>> Delete(string id)
        {
            var prod = await service.GetProduct(id);
            if (prod == null)
            {
                return NotFound();
            }

            await service.DeleteOne(id);

            return Ok();
        }


    }
}
