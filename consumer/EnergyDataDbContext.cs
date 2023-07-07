// <copyright file="EnergyDataDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Consumer
{
    using DotNetEnv;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Define the context of the database and the table for EnergyData model and specify the db provider configuration.
    /// </summary>
    internal class EnergyDataDbContext : DbContext
    {
        /// <summary>
        /// Gets or Sets Representation of EnergyData Entity.
        /// </summary>
        public DbSet<EnergyData> CompanyEnergyData { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=" +
                        Env.GetString("DB_SERVER") +
                        ";Database=Ben; User Id=" +
                        Env.GetString("DB_USER") +
                        "; Password=" +
                        Env.GetString("DB_PASS") +
                        ";TrustServerCertificate=true");
        }
    }
}
