using Shh.Services.Noise.Domain.AggregateModels;
using Shh.Services.Noise.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shh.Services.Noise.Infrastructure.Repositories
{
    internal class NoiseRepository : INoiseRepository
    {
        private readonly NoiseSamplesCollection _samplesCollection;

        public NoiseRepository(NoiseSamplesCollection samplesCollection)
        {
            _samplesCollection = _samplesCollection ?? throw new ArgumentNullException(nameof(samplesCollection));
        }

        public async Task AddSample(NoiseSample sample)
        {
            await _samplesCollection.Collection.InsertOneAsync(sample);
        }

        public async Task AddSamples(IEnumerable<NoiseSample> samples)
        {
            await _samplesCollection.Collection.InsertManyAsync(samples);
        }
    }
}
