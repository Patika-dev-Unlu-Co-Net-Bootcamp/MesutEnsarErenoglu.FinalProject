

using FinalProject.Common.Email;
using RabbitMQ.Client;
using System;
using System.Text;

namespace FinalProject.Common.RabbitMQ
{
    public class RabbitMQReceiver
    {
        public void Send(EmailModel emailModel)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://qfznqsyq:y6jS2z9QcHaiqzPpPwQctHwZaemXJqY6@beaver.rmq.cloudamqp.com/qfznqsyq");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("SendEmail", true, false, false);

            var messagBody = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(emailModel));

            channel.BasicPublish(string.Empty, "SendEmail", null, messagBody);

        }
    }
}
