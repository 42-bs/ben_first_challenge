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

        /// <summary>
        /// Enter description for method SomeMethod.
        /// ID string generated is "M:MyNamespace.MyClass.SomeMethod(System.String,System.Int32@,System.Void*)".
        /// </summary>
        /// <param name="optionsBuilder">Describe parameter.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/db/litedb.sqlite");
        }
    }
}
