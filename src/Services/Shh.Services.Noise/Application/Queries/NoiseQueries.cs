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
        private readonly NoiseSamplesCollection _samplesCollection;

        public NoiseQueries(NoiseSamplesCollection samplesCollection)
        {
            _samplesCollection = _samplesCollection ?? throw new ArgumentNullException(nameof(samplesCollection));
        }

        public IEnumerable<NoiseSample> GetSamples(string deviceId, DateTime? from, DateTime? to)
        {
            var samples = _samplesCollection.Collection
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
