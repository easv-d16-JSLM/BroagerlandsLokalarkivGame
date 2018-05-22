using LiteDB;

namespace BLAG.Common.Models
{
    public class ModelBase
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}