using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.GraphqlBasic
{
    public class Query
    {
        IProductService _service = null;
        public Query(IProductService productService)
        {
            _service = productService;
        }

        public List<Product> Product => _service.GetProducts();

        public List<Product> GetProducts()
        {
            return _service.GetProducts();
        }
    }
}
