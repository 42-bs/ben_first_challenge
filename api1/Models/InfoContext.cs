namespace Api1.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// .
    /// </summary>
    public class InfoContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoContext"/> class.
        /// </summary>
        /// <param name="options">c.</param>
        public InfoContext(DbContextOptions<InfoContext> options)
                : base(options)
        {
            // nothing.
        }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        public DbSet<InfoTable> Company_Energy_Data { get; set; }
    }
}
