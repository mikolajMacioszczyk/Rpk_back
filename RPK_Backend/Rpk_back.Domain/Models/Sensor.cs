using System;
using System.Collections.Generic;
using System.Text;
using Rpk_back.Domain.Enums;

namespace Rpk_back.Domain.Models
{
    public class Sensor
    {
        public Guid SensorId { get; set; }
        public string NodeId { get; set; }
        public DateTime MeasurementTime { get; set; }
        public float SensorValue { get; set; }
        public SensorLocalizationEnum Localization { get; set; }
        public SensorTypeEnum SensorType { get; set; }
        public Guid SensorGroupGuid { get; set; }
    }
}
