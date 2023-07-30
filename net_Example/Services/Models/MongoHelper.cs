using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Mango.Services.ProductAPI.Models
{
    public class MongoHelper
    {
        public static MongoClient? Client;
        public static IMongoDatabase? Database;
        public static void ConnectToMongoService(string MongoConnectionString, string MongoDatabase)
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromConnectionString(MongoConnectionString);
                settings.LinqProvider = LinqProvider.V3;
                Client = new MongoClient(settings);
                Database = Client.GetDatabase(MongoDatabase);

            }
            catch (Exception)
            {

                throw (new Exception("Không kết nối được với database"));
            }
        }

    }
}
