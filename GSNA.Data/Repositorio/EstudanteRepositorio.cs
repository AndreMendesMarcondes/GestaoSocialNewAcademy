using GSNA.Domain.Domain;
using GSNA.Domain.DTO.Settings;
using GSNA.Domain.Interfaces.Repositorio;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GSNA.Data.Repositorio
{
    public class EstudanteRepositorio : IEstudanteRepositorio
    {
        private readonly IMongoCollection<InstagramDetails> _collection;

        public EstudanteRepositorio(IOptions<MongoDBEstudanteSettings> mongoEstudanteSettings)
        {
            var mongoClient = new MongoClient(mongoEstudanteSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoEstudanteSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<InstagramDetails>(mongoEstudanteSettings.Value.CollectionName);
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

        public async Task Insert(InstagramDetails estudante)
        {
            await _collection.InsertOneAsync(estudante);
        }

        public async Task Update(InstagramDetails estudante)
        {
            await _collection.FindOneAndReplaceAsync(c => c.Id == estudante.Id, estudante);
        }
    }
}
