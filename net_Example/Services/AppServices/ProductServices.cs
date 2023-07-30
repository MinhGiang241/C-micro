using Mango.Services.ProductAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Mango.Services.ProductAPI.AppServices
{
    public class ProductServices
    {
        private readonly IMongoCollection<Product> _products;
        private MongoClient client;
        private IMongoDatabase database;
        public ProductServices(DataServices service)
        {
            this.database = service.database;
            this.client = service.client;
            _products = database.GetCollection<Product>("product");
            Console.WriteLine(_products);
        }

        public async Task<List<Product>> GetProducts() => await _products.Find(pro => true).ToListAsync();
        public async Task<List<Product>> GetExpensiveProducts()
        {
            var results = from product in _products.AsQueryable()
                          where product.price > 10
                          select product;
            // await _products.Find(pro => true).ToListAsync();
            return await results.ToListAsync();
        }
        public async Task<Product> GetProduct(string id)
        {
            var product = await _products.Find(pro => pro.Id == id).FirstOrDefaultAsync();
            return product;
        }
        public async Task<Product> Create(Product product)
        {
            await _products.InsertOneAsync(product);
            return product;
        }
        public async Task<Product> Update(string id, Product updatedProduct)
        {
            var results = from prod in _products.AsQueryable()
                          where prod.Id == id
                          select prod;
            var product = await results.FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }
            updatedProduct.Id = id;
            _products.ReplaceOne(p => p.Id == id, updatedProduct);
            return product;
        }
        public async Task<Product> DeleteOne(String id)
        {
            return await _products.FindOneAndDeleteAsync(pro => pro.Id == id);
        }

    }
}
