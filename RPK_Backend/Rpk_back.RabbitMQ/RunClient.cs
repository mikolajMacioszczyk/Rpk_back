using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Rpk_back.RabbitMQ.Client;
using Rpk_back.RabbitMQ.Interfaces;

namespace Rpk_back.RabbitMQ
{
    public class RunClient : IRunClient, IHostedService
    {
        private readonly DataReceiver _dataReceiver;

        public RunClient(DataReceiver dataReceiver)
        {
            _dataReceiver = dataReceiver;
        }

        public void RunMain()
        { 
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(_dataReceiver.Receive, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
