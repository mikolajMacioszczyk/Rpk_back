using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Repository
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetByIdGroupAndTime( );
        Task<Sensor> GetBySensorId();
        Task<IEnumerable<Sensor>> GetByTypeAndTime();
        Task<IEnumerable<Sensor>> GetByLocalizationAndTime();
    }
}