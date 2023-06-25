using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.GraphqlBasic
{
    public class ProductQuery
    {
        IProductService _service = null;
        public ProductQuery(IProductService productService)
        {
            _service = productService;
        }

        public List<Product> Product => _service.GetProducts();

    }
}
