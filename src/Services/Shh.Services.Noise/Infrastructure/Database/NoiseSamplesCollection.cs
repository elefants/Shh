using MongoDB.Driver;
using Shh.Extensions.DependencyInjection.NoSql;
using Shh.Services.Noise.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Infrastructure.Database
{
    public class NoiseSamplesCollection
    {
        private readonly IMongoDatabase _database = null;

        public NoiseSamplesCollection(NoSqlCollectionOptions<NoiseSamplesCollection> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<NoiseSample> Collection => _database.GetCollection<NoiseSample>("noise-samples");
    }
}
