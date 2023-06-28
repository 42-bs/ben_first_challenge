namespace api1.Models;

public class InfoTable
	{
		public int Id { get; set; }
		public long CompanyId { get; set; }
		public string? ConsumerUnity { get; set; }
		public double? Value { get; set; }
		public DateTime Timestamp { get; set; }
	}
