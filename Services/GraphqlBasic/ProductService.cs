using Mango.Services.ProductAPI.GraphqlBasic;
using Mango.Services.ProductAPI.Models;

public class ProductService : IProductService

{
    public List<Product> GetProducts()
    {
        List<Product> products = new List<Product>();
        for (int i = 0; i < 9; i++)
        {
            products.Add(new Product { Name = "Hello", price = i * 100, Description = "dồ con gà" });
        }

        return products;
    }
}
