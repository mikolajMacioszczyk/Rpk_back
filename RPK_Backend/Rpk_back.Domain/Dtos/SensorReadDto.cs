using System;
using Rpk_back.Domain.Enums;

namespace Rpk_back.Domain.Dtos
{
    public class SensorReadDto
    {
        public Guid SensorId { get; set; }
        public DateTime MeasurementTime { get; set; }
        public float SensorValue { get; set; }
        public string Localization { get; set; }
        public string SensorType { get; set; }
        public Guid SensorGroupGuid { get; set; }
    }
}