using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQClient;
using System.Text;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};
using (var connection = factory.CreateConnection())
{
    using (var channel = connection.CreateModel())
    {
        try
        {
            channel.QueueDeclare(queue: "radoreq", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                Product getProduct = new Product();
                var message = Encoding.UTF8.GetString(body);
                getProduct = JsonConvert.DeserializeObject<Product>(message);
                Console.WriteLine("Okunan ürün: " + getProduct.Name);
            };
            channel.BasicConsume(queue: "radoreq", autoAck: true, consumer: consumer);
            Console.WriteLine("Çıkmak için bir tuşa basınız");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}