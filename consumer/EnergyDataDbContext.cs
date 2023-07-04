// <copyright file="EnergyDataDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Consumer
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Define the context of the database and the table for EnergyData model and specify the db provider configuration.
    /// </summary>
    internal class EnergyDataDbContext : DbContext
    {
        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public DbSet<EnergyData> Company_Energy_Data { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Data Source=/db/litedb.sqlite");
            // optionsBuilder.UseSqlServer(@"Server=localhost;Database=Ben; User Id=SA; Password=Bosch42$;TrustServerCertificate=true");
			optionsBuilder.UseSqlServer(@"Server=sqlserver1;Database=Ben; User Id=SA; Password=Bosch42$;TrustServerCertificate=true");
        }
    }
}
