using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rpk_back.Application.Interfaces;
using Rpk_back.Domain.Dtos;
using Rpk_back.Domain.Enums;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Service
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;
        private readonly IMapper _mapper;

        public SensorService(ISensorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SensorReadDto> GetByIdAndTime(Guid sensorId)
        {
            return _mapper.Map<SensorReadDto>(await _repository.GetBySensorId(sensorId));
        }

        public async Task<IEnumerable<SensorReadDto>> GetGroupByIdAndTime(Guid groupId, DateTime startTime, DateTime endTime)
        {
            return _mapper.Map<IEnumerable<SensorReadDto>>(await _repository.GetByIdGroupAndTime(groupId, startTime, endTime));
        }

        public async Task<IEnumerable<SensorReadDto>> GetByLocalizationAndTIme(SensorLocalizationEnum localization, DateTime startTime, DateTime endTime)
        {
            return _mapper.Map<IEnumerable<SensorReadDto>>(await _repository.GetByLocalizationAndTime(localization, startTime, endTime));
        }

        public async Task<IEnumerable<SensorReadDto>> GetByTypeAndTIme(SensorTypeEnum sensorType, DateTime startTime, DateTime endTime)
        {
            return _mapper.Map<IEnumerable<SensorReadDto>>(await _repository.GetByTypeAndTime(sensorType, startTime, endTime));
        }

        public async Task AddSensor(Sensor sensor)
        {
            await _repository.CreateSensor(sensor);
        }
    }
}