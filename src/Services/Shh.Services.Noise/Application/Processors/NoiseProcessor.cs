using Shh.Services.Noise.Application.Models;
using Shh.Services.Noise.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shh.Services.Noise.Application.Processors
{
    public class NoiseProcessor
    {
        private readonly INoiseQueries _noiseQueries;

        public NoiseProcessor(INoiseQueries noiseQueries)
        {
            _noiseQueries = noiseQueries;
        }

        public NoiseStatistics CalculateStatistics(string deviceId, DateTime? from, DateTime? to)
        {
            var samples = _noiseQueries.GetSamples(deviceId, from, null);
            if (!samples.Any())
                return null;

            var statistics = new NoiseStatistics
            {
                From = samples.Min(x => x.TimeStamp),
                To = samples.Max(x => x.TimeStamp),
                AvgValue = samples.Average(x => x.Value),
            };
            return statistics;
        }
    }
}
