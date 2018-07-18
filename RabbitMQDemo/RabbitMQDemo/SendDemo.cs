using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Send
{
    class SendDemo
    {
        static void Main(string[] args)
        {
            try
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
                        while (true)
                        {
                            channel.QueueDeclare("hello", false, false, false, null);
                            Console.WriteLine("input string to send ：");
                            object message = Console.ReadLine();
                            var body = Encoding.UTF8.GetBytes(message.ToString());
                            channel.BasicPublish("", "hello", null, body);
                            Console.WriteLine(" send {0}", message);
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.ToString());
            }
            Console.ReadLine();
        }
    }
}
