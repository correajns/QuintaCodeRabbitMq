using Dominio;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Receptor
{
    class Program
    {
        const string _hostname = "localhost";
        const string _routingKey = "rmqs";
        const string _queue = "qcrs";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            Mensagem mensagem = null;

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                //utilizado para equilibrar os evios para multiplas filas
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                consumer.Received += (model, ea) =>
                {
                    
                    /*
                     Se tudo der certo remove os itens da fila
                    caso de errado mantem o objeto na fila
                     */
                    try
                    {
                        var body = ea.Body.ToArray();
                        mensagem = Encoding.UTF8.GetString(body).FromJson();
                        Console.WriteLine(mensagem.MensagemInOut);

                        Thread.Sleep(new Random().Next(1000, 5000));

                        //remove o item da fila
                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        //retorna o item a fila
                        channel.BasicNack(ea.DeliveryTag, false, true);
                        Console.WriteLine(ex.Message);

                    }

                };
                channel.BasicConsume(queue: _queue,
                                     autoAck: false,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
