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
        public DbSet<EnergyData> My_Info_Table { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/db/litedb.sqlite");
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyIdData>()
                .HasMany(e => e.EnergyDatas)
                .WithOne(e => e.CompanyIdData)
                .HasForeignKey(e => e.CompanyIdDataFK)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
