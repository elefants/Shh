using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shh.Services.Noise.Domain.AggregateModels
{
    public interface INoiseRepository
    {
        Task AddSamples(IEnumerable<NoiseSample> samples);
    }
}
