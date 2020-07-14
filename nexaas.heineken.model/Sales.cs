using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace nexaas.heineken.model
{
    public class Sales
    {
        [BsonExtraElements]
        public BsonDocument CatchAll { get; set; }
    }
}
