using System;
using System.Threading.Tasks;

namespace Rpk_back.Application.Interfaces
{
    interface IApplicationMemoryStore
    {
        T Get<T>(string key);
        void Set<T>(string itemKey, T itemValue, DateTime expirationDate);
        bool Contains(string key);
        void Remove(string key);
    }
}
