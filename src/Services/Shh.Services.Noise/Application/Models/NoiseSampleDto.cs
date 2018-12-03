using System;
using System.Collections.Generic;
using System.Text;

namespace Shh.Services.Noise.Application.Models
{
    public class NoiseSampleDto
    {
        public DateTime TimeStamp { get; set; }
        public decimal Value { get; set; }
    }
}
