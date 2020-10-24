using System;
using System.Collections.Generic;
using System.Text;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Interfaces
{
    public interface IRegisterService
    {
        void RegisteredNode(RegisterNode node);

        List<RegisterNode> GetRegisterNodes();
    }
}
