using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mango.Services.ProductAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonElement("price")]
        [BsonIgnoreIfNull]
        public double price { get; set; }

        [BsonElement("description")]
        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonElement("categoryname")]
        [BsonIgnoreIfNull]
        public string CategoryName { get; set; }

        [BsonElement("imageurl")]
        [BsonIgnoreIfNull]
        public string ImageUrl { get; set; }
    }
}
