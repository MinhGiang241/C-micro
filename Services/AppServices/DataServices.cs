using Mango.Services.ProductAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Mango.Services.ProductAPI.AppServices
{
    public class DataServices
    {

        public MongoClient client;
        public IMongoDatabase database;
        public DataServices(IOptions<DataSetting> settings)
        {
            var linqSettings = MongoClientSettings.FromConnectionString(
                settings.Value.ConnectionString
                );

            linqSettings.LinqProvider = LinqProvider.V3;
            client = new MongoClient(linqSettings);
            database = client.GetDatabase(settings.Value.DatabaseName);
        }


    }
}
