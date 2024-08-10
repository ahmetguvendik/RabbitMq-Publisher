using System.Text;
using RabbitMQ.Client;


//Baglanti Olusturma
ConnectionFactory connectionFactory = new();
connectionFactory.Uri = new Uri("amqps://wqbvawvt:aTi_gA9eIEH4Ot3LV4PDfWHGFZieaNK-@shark.rmq.cloudamqp.com/wqbvawvt");

//Baglantiyi Aktif Etme
using IConnection connection = connectionFactory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Olusturma
channel.QueueDeclare(queue: "example-queeue", exclusive: false);

//Queue a mesaj gonderme
//Rabbitmq kuyruga atacagiz mesajlari byte turunde kabul etmektedir. Mesajlari byte a donusturmek gerekiyor.

byte[] message = Encoding.UTF8.GetBytes("Merhaba");
channel.BasicPublish(exchange: "", routingKey: "example-queeue", body: message);
//Eger ki exchange e bir isim vermezsek default olarak DirectExchange olarak calisacaktir.

Console.Read();