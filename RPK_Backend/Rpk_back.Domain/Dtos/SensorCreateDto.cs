using System;
using System.ComponentModel.DataAnnotations;

namespace Rpk_back.Domain.Dtos
{
    public class SensorCreateDto
    {
        [Key]
        [Required]
        public Guid SensorId { get; set; }
        [Required]
        public DateTime MeasurementTime { get; set; }
        [Required]
        public float SensorValue { get; set; }
        [Required]
        public int Localization { get; set; }
        [Required]
        public int SensorType { get; set; }
        [Required]
        public Guid SensorGroupGuid { get; set; }
    }
}