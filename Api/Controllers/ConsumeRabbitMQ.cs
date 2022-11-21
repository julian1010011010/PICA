using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Api.Controllers
{
    public  class ConsumeRabbitMQ
    {
        private ProjectController _projectController;
        public ConsumeRabbitMQ(ProjectController ProjectController)
        {

            _projectController = ProjectController;
        }

        public void RunRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "172.17.0.4",
            };


            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "ColaPICA", durable: false, exclusive: false, autoDelete: false, arguments: null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        int idProject = Int32.Parse(Encoding.UTF8.GetString(body));

                        _projectController.GetChangeStatusProject(idProject);
                    };
                    channel.BasicConsume(queue: "ColaPICA", autoAck: true, consumer: consumer);
                }
            }
        }
    }
}