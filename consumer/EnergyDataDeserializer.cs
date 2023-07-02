// <copyright file="EnergyDataDeserializer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Consumer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using Newtonsoft.Json;

    /// <summary>
    /// Custom deserializer class for consumer.
    /// </summary>
    internal class EnergyDataDeserializer : IDeserializer<EnergyData>
    {
        /// <summary>
        /// Deserialize from json to dict, and from dict to EnergyData.
        /// </summary>
        /// <param name="data">ReadOnly representation of the data read from kafka.</param>
        /// <param name="isNull">Check if the data is null.</param>
        /// <param name="context">The relevant context about the serialization.</param>
        /// <returns>An EnergyData Object, ready to be send as model to database.</returns>
        public EnergyData Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
            {
                return null;
            }

            var jsonString = Encoding.UTF8.GetString(data).Trim('"').Replace("\\\"", "\"");
            Dictionary<string, object>? dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            return new EnergyData();
        }
    }
}
