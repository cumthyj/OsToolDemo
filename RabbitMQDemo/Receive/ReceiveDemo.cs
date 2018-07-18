using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receive
{
    class ReceiveDemo
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.HostName = "101.132.114.233";
            factory.UserName = "hyj";
            factory.Password = "123qwe";
            factory.Port = 5672;

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("hello", true, consumer);

                    Console.WriteLine(" waiting for message.");
                    while (true)
                    {
                        var ea = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine("Received {0}", message);

                    }
                }
            }
        }
    }
}
