using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Repository
{
    public class SensorRepository : ISensorRepository
    {
        public Task<IEnumerable<Sensor>> GetByIdGroupAndTime()
        {
            throw new System.NotImplementedException();
        }

        public Task<Sensor> GetBySensorId()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Sensor>> GetByTypeAndTime()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Sensor>> GetByLocalizationAndTime()
        {
            throw new System.NotImplementedException();
        }
    }
}