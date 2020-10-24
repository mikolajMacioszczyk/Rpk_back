using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rpk_back.Application.Db;
using Rpk_back.Application.Repository.Interface;
using Rpk_back.Domain.Enums;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Repository.Implementation
{
    public class SensorRepository : ISensorRepository
    {
        private readonly Context _db;

        public SensorRepository(Context db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Sensor>> GetByIdGroupAndTime(Guid groupId, DateTime startTimer, DateTime endTime)
        {
            return await _db.SensorItems.Where(s => s.SensorGroupGuid == groupId)
                .Where(s => s.MeasurementTime >= startTimer && s.MeasurementTime <= endTime).ToListAsync();
        }

        public async Task<Sensor> GetBySensorId(Guid sensorId)
        {
            return await _db.SensorItems.Where(s => s.SensorId == sensorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Sensor>> GetByTypeAndTime(SensorTypeEnum sensorType, DateTime startTimer, DateTime endTime)
        {
            return await _db.SensorItems.Where(s => s.SensorType == sensorType)
                .Where(s => s.MeasurementTime >= startTimer && s.MeasurementTime <= endTime).ToListAsync();
        }

        public async Task<IEnumerable<Sensor>> GetByLocalizationAndTime(SensorLocalizationEnum localization, DateTime startTimer, DateTime endTime)
        {
            return await _db.SensorItems.Where(s => s.Localization == localization)
                .Where(s => s.MeasurementTime >= startTimer && s.MeasurementTime <= endTime).ToListAsync();
        }

        public async Task<Sensor> CreateSensor(Sensor created)
        {
            await _db.SensorItems.AddAsync(created);
            return created;
        }
    }
}