using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Interfaces
{
    public interface IApplicationMemoryStore
    {
        List<RegisterNode> GetCachedRegisteredNodes();
    }
}
