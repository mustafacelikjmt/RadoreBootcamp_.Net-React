using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQProducerOrnek.Models;
using System.Diagnostics;
using System.Text;

namespace RabbitMQProducerOrnek.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
                        Product p1 = new Product();
                        p1.Id = 1;
                        p1.Name = "Ürün 1";
                        p1.Price = 30;
                        var json = JsonConvert.SerializeObject(p1);
                        var body = Encoding.UTF8.GetBytes(json);
                        channel.BasicPublish(exchange: "", routingKey: "radoreq", basicProperties: null, body: body);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}