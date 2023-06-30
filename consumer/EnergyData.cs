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
        /// Gets or Sets Get any text here.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public long CompanyId { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public string? ConsumerUnity { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        public double? Value { get; set; }

        /// <summary>
        /// Gets or Sets Get any text here.
        /// </summary>
        [Column(TypeName = "DATE")]
        public DateTime Timestamp { get; set; }
    }
}