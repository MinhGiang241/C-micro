using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.GraphqlBasic
{


    public interface IProductService
    {
        public List<Product> GetProducts();
    }

}
