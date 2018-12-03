using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Application.Models
{
    public class NoiseStatistics
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public decimal AvgValue { get; set; }
    }
}
