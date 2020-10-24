using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Enums;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Repository.Interface
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetByIdGroupAndTime(Guid groupId, DateTime startTimer, DateTime endTime);
        Task<Sensor> GetBySensorId(Guid sensorId);
        Task<IEnumerable<Sensor>> GetByTypeAndTime(SensorTypeEnum sensorType, DateTime startTimer, DateTime endTime);
        Task<IEnumerable<Sensor>> GetByLocalizationAndTime(SensorLocalizationEnum localization, DateTime startTimer, DateTime endTime);
        Task<Sensor> CreateSensor(Sensor created);
    }
}