using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Dtos;
using Rpk_back.Domain.Enums;

namespace Rpk_back.Application.Interfaces
{
    public interface ISensorService
    {
        Task<SensorReadDto> GetByIdAndTime(Guid sensorId);
        Task<IEnumerable<SensorReadDto>> GetGroupByIdAndTime(Guid groupId, DateTime startTime, DateTime endTime);
        Task<IEnumerable<SensorReadDto>> GetByLocalizationAndTIme(SensorLocalizationEnum localization, DateTime startTime, DateTime endTime);
        Task<IEnumerable<SensorReadDto>> GetByTypeAndTIme(SensorTypeEnum sensorType, DateTime startTime, DateTime endTime);
    }
}