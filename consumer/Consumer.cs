using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;

class Consumer
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("cavalinho");
        await Task.Delay(TimeSpan.FromSeconds(10));
        Console.WriteLine("cavalinho2");

        var config = new ConsumerConfig
        {
            GroupId = "test-consumer",
            BootstrapServers = "kafka:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<string, Dictionary<string, object>>(config).
            SetValueDeserializer(new DeserializeDictionary()).Build();

        {
            consumer.Subscribe("random_energy_data");

            var cancellationTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true;
                cancellationTokenSource.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        var consumerResult = consumer.Consume(cancellationTokenSource.Token);
                        var message = consumerResult.Message;
                        Console.WriteLine($"\nConsumed message 'ID: {message.Key}' at: '{consumerResult.TopicPartitionOffset}'.");
                        foreach (var item in message.Value)
                        {
                            Console.WriteLine($"Key: {item.Key}\t: {item.Value}");
                        }
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }

    public class DeserializeDictionary : IDeserializer<Dictionary<string, object>>
    {
        public Dictionary<string, object> Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
            {
                return null;
            }

            var jsonString = Encoding.UTF8.GetString(data).Trim('"').Replace("\\\"", "\"");
            Dictionary<string, object> ?dict = JsonConvert.DeserializeObject<Dictionary<string,object>>(jsonString);

            return dict;
        }
    }
}
