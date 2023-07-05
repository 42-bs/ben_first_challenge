// <copyright file="EnergyDataDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api1.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Define the context of the database and the table for EnergyData model and specify the db provider configuration.
    /// </summary>
    public class EnergyDataDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnergyDataDbContext"/> class.
        /// </summary>
        /// <param name="options">Start point of all DbContext configuration.</param>
        public EnergyDataDbContext(DbContextOptions<EnergyDataDbContext> options)
                : base(options)
        {
        }

        /// <summary>
        /// Gets or Sets Representation of EnergyData Entity.
        /// </summary>
        public DbSet<EnergyData> Company_Energy_Data { get; set; }
    }
}
