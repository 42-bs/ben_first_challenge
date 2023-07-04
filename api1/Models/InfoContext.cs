using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api1.Models;

public class InfoContext : DbContext
{
	public DbSet<InfoTable> Company_Energy_Data { get; set; }
	// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	// {
	// 	optionsBuilder.UseSqlite("Data Source=../consumer/litedb.sqlite");
	// }
	public InfoContext(DbContextOptions<InfoContext> options)
            : base(options)
        {
        }
}
