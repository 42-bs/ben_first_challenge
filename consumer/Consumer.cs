using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace consumer
{
	public class InfoContext : DbContext
	{
		public DbSet<InfoTable> My_Info_Table { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=litedb.sqlite");
		}

		// protected override void OnModelCreating(ModelBuilder modelBuilder)
		// {
		// 	modelBuilder.Entity<InfoTable>()
		// 		.HasKey(i => i.CompanyId);
		// }
	}
	public class InfoTable
	{
		[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public long CompanyId { get; set; }
		public string? ConsumerUnity { get; set; }
		public double? Value { get; set; }
		public DateTime Timestamp { get; set; }
	}
    public class Consumer
    {
        public static async Task Main(string[] args)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

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
                            Console.WriteLine($"\nConsumed message at: '{consumerResult.TopicPartitionOffset}'.");
							using (var db = new InfoContext())
							{
								InfoTable infotable = new InfoTable();
								infotable.CompanyId = long.Parse(message.Key);
								infotable.ConsumerUnity = message.Value["Consumer Unity"].ToString();
								infotable.Value = double.Parse(message.Value["Value"].ToString());
								infotable.Timestamp = DateTime.FromFileTime(Convert.ToInt64(message.Value["Timestamp"]));
								db.My_Info_Table.Add(infotable);
								db.SaveChanges();
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
}