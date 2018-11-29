using Shh.Services.Noise.Domain.AggregateModels;
using Shh.Services.Noise.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Infrastructure.Repositories
{
    internal class NoiseRepository : INoiseRepository
    {
        private readonly NoiseSamplesCollection _samplesCollection;

        public NoiseRepository(NoiseSamplesCollection samplesCollection)
        {
            _samplesCollection = _samplesCollection ?? throw new ArgumentNullException(nameof(samplesCollection));
        }
    }
}
