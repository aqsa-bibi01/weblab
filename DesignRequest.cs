using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuraVisualsAPI.Models
{
    public class DesignRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }

        public string ClientName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ServiceType { get; set; } = null!;

        public string ProjectDescription { get; set; } = null!;

        public double Budget { get; set; }

        public string Status { get; set; } = "Pending";
    }
}