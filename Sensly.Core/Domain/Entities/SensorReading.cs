using System;
using System.Collections.Generic;
using System.Text;

namespace Sensly.Core.Domain.Entities
{
    public class SensorReading
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public float Value { get; set; }
        public Guid SensorId { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow; 

        public Sensor Sensor { get; set; }
    }
}
