using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Rpk_back.Application.Repository.Interface;
using Rpk_back.Application.Service.Interface;
using Rpk_back.Domain.Dtos;

namespace Rpk_back.Application.Service.Implementation
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

        public async Task<SensorReadDto> GetByIdAndTime(Guid sensorId, DateTime time)
        {
            return await _repository.GetBySensorId(sensorId, time);
        }

        public Task<IEnumerable<SensorReadDto>> GetGroupByIdAndTime(Guid groupId, DateTime time)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SensorReadDto>> GetByLocalizationAndTIme(Guid groupId, DateTime time)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SensorReadDto>> GetByTypeAndTIme(Guid groupId, DateTime time)
        {
            throw new NotImplementedException();
        }
    }
}