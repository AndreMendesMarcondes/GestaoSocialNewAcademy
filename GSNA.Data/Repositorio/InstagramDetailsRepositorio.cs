using GSNA.Domain.Domain;
using GSNA.Domain.DTO.Settings;
using GSNA.Domain.Interfaces.Repositorio;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GSNA.Data.Repositorio
{
    public class InstagramDetailsRepositorio : IInstagramDetailsRepositorio
    {
        private readonly IMongoCollection<InstagramDetails> _collection;
        private static string COLLECTION = "InstagramDetails";

        public InstagramDetailsRepositorio(IOptions<MongoDBSettings> mongoInstagramDetailsSettings)
        {
            var mongoClient = new MongoClient(mongoInstagramDetailsSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoInstagramDetailsSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<InstagramDetails>(COLLECTION);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<InstagramDetails>> GetAll()
        {
            var result = await _collection.FindAsync(c => true);
            return result.ToList();
        }

        public async Task<List<InstagramDetails>?> GetById(string id)
        {
            var result = await _collection.FindAsync(c => c.Id == id);
            return result.ToList();
        }

        public async Task Insert(InstagramDetails instagramDetails)
        {
            await _collection.InsertOneAsync(instagramDetails);
        }

        public async Task Update(InstagramDetails instagramDetails)
        {
            await _collection.FindOneAndReplaceAsync(c => c.Id == instagramDetails.Id, instagramDetails);
        }
    }
}
