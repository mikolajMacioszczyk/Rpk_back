using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Dtos;

namespace Rpk_back.Application.Service.Interface
{
    public interface ISensorService
    {
        Task<SensorReadDto> GetByIdAndTime(Guid sensorId, DateTime time);
        Task<IEnumerable<SensorReadDto>> GetGroupByIdAndTime(Guid groupId, DateTime time);
        Task<IEnumerable<SensorReadDto>> GetByLocalizationAndTIme(Guid groupId, DateTime time);
        Task<IEnumerable<SensorReadDto>> GetByTypeAndTIme(Guid groupId, DateTime time);
    }
}