// <copyright file="InfoTable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Api1.Models
{
    /// <summary>
    /// This class get data received from Database to Api1 Schema.
    /// </summary>
    public class InfoTable
    {
        /// <summary>
        /// Gets or Sets Primary Key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Representation of CompanyID as long.
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or sets Representation of Consumer Unity as string.
        /// </summary>
        public string? ConsumerUnity { get; set; }

        /// <summary>
        /// Gets or sets Representation of cost Value as double.
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// Gets or sets Representation of date as DateTime.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
