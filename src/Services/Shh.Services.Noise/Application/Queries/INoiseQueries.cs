using Shh.Services.Noise.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Application.Queries
{
    public interface INoiseQueries
    {
        IEnumerable<NoiseSample> GetSamples(string deviceId, DateTime? from, DateTime? to);
    }
}
