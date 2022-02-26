using FinalProject.Common.Email;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Common.RabbitMQ
{
    public class RabbitMQConsumer
    {
        public void Consume()
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://qfznqsyq:y6jS2z9QcHaiqzPpPwQctHwZaemXJqY6@beaver.rmq.cloudamqp.com/qfznqsyq");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("SendEmail", false, consumer);

            consumer.Received += (object sender, BasicDeliverEventArgs e) => {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());

                EmailModel emailModel =  System.Text.Json.JsonSerializer.Deserialize<EmailModel>(message);

                EmailSender emailSender = new EmailSender();
                emailSender.SendEmail(emailModel);

                channel.BasicAck(e.DeliveryTag, false); 
            };
        }
    }
}
