using MongoDB.Driver;
using Shh.Services.Noise.Domain.AggregateModels;
using Shh.Services.Noise.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shh.Services.Noise.Application.Queries
{
    internal class NoiseQueries : INoiseQueries
    {
        private readonly NoiseDatabase _samplesCollection;

        public NoiseQueries(NoiseDatabase samplesCollection)
        {
            _samplesCollection = _samplesCollection ?? throw new ArgumentNullException(nameof(samplesCollection));
        }

        public IEnumerable<NoiseSample> GetSamples(string deviceId, DateTime? from, DateTime? to)
        {
            var samples = _samplesCollection.SamplesCollection
                .AsQueryable()
                .Where(x => x.DeviceId == deviceId);

            if (from.HasValue)
                samples = samples.Where(x => x.TimeStamp >= from.Value);

            if (to.HasValue)
                samples = samples.Where(x => to.Value >= x.TimeStamp);

            return samples.ToList();
        }
    }
}
