// <copyright file="InfoContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api1.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Define the context of the database and the table for EnergyData model and specify the db provider configuration.
    /// </summary>
    public class InfoContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InfoContext"/> class.
        /// </summary>
        /// <param name="options">Start point of all DbContext configuration.</param>
        public InfoContext(DbContextOptions<InfoContext> options)
                : base(options)
        {
            // nothing.
        }

        /// <summary>
        /// Gets or Sets Representation of InfoTable Entity.
        /// </summary>
        public DbSet<InfoTable> Company_Energy_Data { get; set; }
    }
}
