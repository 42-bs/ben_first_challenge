using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api1.Models;

public class InfoContext : DbContext
{
	public DbSet<InfoTable>? My_Info_Table { get; set; }

	public InfoContext(DbContextOptions<InfoContext> options)
            : base(options)
        {
        }
}
