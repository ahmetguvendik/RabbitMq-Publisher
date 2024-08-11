using System.Text;
using RabbitMQ.Client;


//Baglanti Olusturma
ConnectionFactory connectionFactory = new();
connectionFactory.Uri = new Uri("amqps://wqbvawvt:aTi_gA9eIEH4Ot3LV4PDfWHGFZieaNK-@shark.rmq.cloudamqp.com/wqbvawvt");

//Baglantiyi Aktif Etme
using IConnection connection = connectionFactory.CreateConnection();
using IModel channel = connection.CreateModel();

//Queue Olusturma
channel.QueueDeclare(queue: "example-queeue", exclusive: false,durable:true); //Kuyruktaki veri kalici olsun diye

IBasicProperties properties = channel.CreateBasicProperties();
properties.Persistent = true;

//Queue a mesaj gonderme
//Rabbitmq kuyruga atacagiz mesajlari byte turunde kabul etmektedir. Mesajlari byte a donusturmek gerekiyor.
for (int i = 0; i < 100; i++)
{
    byte[] message = Encoding.UTF8.GetBytes("Merhaba" + i);
    channel.BasicPublish(exchange: "", routingKey: "example-queeue", body: message, basicProperties: properties);
}


//Eger ki exchange e bir isim vermezsek default olarak DirectExchange olarak calisacaktir.

Console.Read();