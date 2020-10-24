using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Rpk_back.Application.Interfaces;
using Rpk_back.Domain.Models;

namespace Rpk_back.Application.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly List<RegisterNode> _list = new List<RegisterNode>();

        public void RegisteredNode(RegisterNode node)
        {
            _list.Add(node);
        }

        public List<RegisterNode> GetRegisterNodes()
        {
            return _list;
        }
    }
}
