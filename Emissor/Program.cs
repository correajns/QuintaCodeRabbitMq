using Dominio;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Emissor
{
    class Program
    {

        const string _hostname = "localhost";
        const string _routingKey = "qcrs";
        const string _queue = "qcrs";
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queue,
                                     durable: false, //true para gravar em disco e não perder informações durante restart
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);



                var rnd = new Random();
                string mask = "id: {0},  processando item {1} de {2}";
                byte[] body = null;
                int max = rnd.Next(100, 1000);

                //loop através do envio
                /*
                    envio em lote para a fila
                    não instancie varias vezes a abertura da fila conforme foi feito acima é isso que faz perder performance :;
                 */
                for (int i = 0; i < max; i++)
                {
                    Mensagem mensagem = new Mensagem
                    {
                        ID = rnd.Next(0, int.MaxValue),
                        JobNum = i,
                        MaxJobs = max
                    };


                    mensagem.MensagemInOut = string.Format(mask, new object[] { mensagem.ID, mensagem.JobNum, mensagem.MaxJobs });

                    body = Encoding.UTF8.GetBytes(mensagem.ToJson());
                    channel.BasicPublish(exchange: "",
                                     routingKey: _routingKey,
                                     basicProperties: null,
                                     body: body);
                    Console.WriteLine(mensagem.MensagemInOut);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
