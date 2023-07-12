// <copyright file="EnergyDataDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api1.Models
{
    using Microsoft.EntityFrameworkCore;

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
        public DbSet<EnergyData> CompanyEnergyData { get; set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnergyData>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}
