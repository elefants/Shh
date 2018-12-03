using Microsoft.AspNetCore.SignalR;
using Shh.Services.Noise.Application.Models;
using Shh.Services.Noise.Application.Processors;
using Shh.Services.Noise.Application.Queries;
using Shh.Services.Noise.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shh.Services.Noise.Application.Hubs
{
    public class NoiseHub : Hub
    {
        private readonly INoiseRepository _noiseRepository;
        private readonly INoiseQueries _noiseQueries;
        private readonly NoiseProcessor _noiseProcessor;

        public NoiseHub(INoiseRepository noiseRepository,
            INoiseQueries noiseQueries,
            NoiseProcessor noiseProcessor)
        {
            _noiseRepository = noiseRepository;
            _noiseQueries = noiseQueries;
            _noiseProcessor = noiseProcessor;
        }

        public async Task SendSample(NoiseSampleDto sample)
        {
            var deviceId = GetDeviceId();
            var sampleData = new NoiseSample
            {
                Id = Guid.NewGuid(),
                DeviceId = deviceId,
                TimeStamp = sample.TimeStamp,
                Value = sample.Value,
            };
            await _noiseRepository.AddSample(sampleData);

            var statistics = _noiseProcessor.CalculateStatistics(
                deviceId,
                sample.TimeStamp.AddMinutes(-30),
                null);
            await Clients.Caller.SendAsync("NewStatistics", statistics);
        }

        private string GetDeviceId()
        {
            return Context.GetHttpContext().Request.Host.Host;
        }
    }
}
