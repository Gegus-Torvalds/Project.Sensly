using System;
using System.Collections.Generic;
using System.Text;
using Sensly.Core.Enums;

namespace Sensly.Core.Domain.Entities
{
    public class Sensor
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public string? SensorName { get; set; }

        public UnitOfMeasurement Unit { get; set; } = UnitOfMeasurement.DegreesCelsius;
    }
}
