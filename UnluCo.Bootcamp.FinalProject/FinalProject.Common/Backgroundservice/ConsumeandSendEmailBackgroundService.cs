using FinalProject.Common.RabbitMQ;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject.Common.Backgroundservice
{
    public class ConsumeandSendEmailBackgroundService : BackgroundService
    {
        RabbitMQConsumer rabbit;
        
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            rabbit = new RabbitMQConsumer();
            return base.StartAsync(cancellationToken);

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            rabbit.Consume();
            return Task.CompletedTask;
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }

    }
}
