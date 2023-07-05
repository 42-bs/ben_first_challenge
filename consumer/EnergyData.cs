// <copyright file="EnergyData.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Consumer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// This class get data received from Kafka and convert to Database schema.
    /// </summary>
    public class EnergyData
    {
        /// <summary>
        /// Gets or Sets Primary Key.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Representation of CompanyID as long.
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or Sets Representation of Consumer Unity as string.
        /// </summary>
        public string? ConsumerUnity { get; set; }

        /// <summary>
        /// Gets or Sets Representation of cost Value as double.
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// Gets or Sets Representation of date as DateTime.
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
