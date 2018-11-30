using Shh.Foundation.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Domain.AggregateModels
{
    public class NoiseSample : Entity<Guid>, 
        IAggregateRoot
    {
        public string DeviceId { get; set; }

        public DateTime TimeStamp { get; set; }

        public decimal Value { get; set; }
    }
}
