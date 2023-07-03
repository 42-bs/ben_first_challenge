// <copyright file="Consumer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Consumer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using Newtonsoft.Json;

    /// <summary>
    /// Consume from kafka and send to the database.
    /// </summary>
    public class Consumer
    {
        /// <summary>
        /// This main aims to read from a single topic and add to a single table in the database,
        /// the goal is just to fill the database with lots of information.
        /// </summary>
        /// <returns>Represents an asynchonous task operation.</returns>
        public static async Task Main()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

            var config = new ConsumerConfig
            {
                GroupId = "test-consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<Null, EnergyData>(config).
                SetValueDeserializer(new EnergyDataDeserializer()).Build();
            {
                consumer.Subscribe("random_energy_data");

                var cancellationTokenSource = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
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
                            Console.WriteLine($"\nConsumed message at: '{consumerResult.TopicPartitionOffset}'.");

                            // using (var db = new EnergyDataDbContext())
                            // {
                            //    EnergyData energyData = message.Value;
                            //    db.My_Info_Table.Add(energyData);
                            //    db.SaveChanges();
                            // }
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
    }
}