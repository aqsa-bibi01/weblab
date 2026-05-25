using AuraVisualsAPI.Models;
using MongoDB.Driver;

namespace AuraVisualsAPI.Services
{
    public class RequestService
    {
        private readonly IMongoCollection<DesignRequest> _requests;

        public RequestService(IConfiguration config)
        {
            var client = new MongoClient(
                config["MongoDbSettings:ConnectionString"]);

            var database = client.GetDatabase(
                config["MongoDbSettings:DatabaseName"]);

            _requests = database.GetCollection<DesignRequest>(
                config["MongoDbSettings:CollectionName"]);
        }

        public async Task<List<DesignRequest>> GetAsync() =>
            await _requests.Find(_ => true).ToListAsync();

        public async Task CreateAsync(DesignRequest request) =>
            await _requests.InsertOneAsync(request);

        public async Task UpdateAsync(string id, DesignRequest request) =>
            await _requests.ReplaceOneAsync(x => x.Id == id, request);

        public async Task DeleteAsync(string id) =>
            await _requests.DeleteOneAsync(x => x.Id == id);
    }
}