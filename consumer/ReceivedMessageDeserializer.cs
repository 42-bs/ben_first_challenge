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
    internal class ReceivedMessageDeserializer : IDeserializer<ReceivedMessage>
    {
        /// <summary>
        /// Deserialize from json to dict, and from dict to EnergyData.
        /// </summary>
        /// <param name="data">ReadOnly representation of the data read from kafka.</param>
        /// <param name="isNull">Check if the data is null.</param>
        /// <param name="context">The relevant context about the serialization.</param>
        /// <returns>An EnergyData Object, ready to be send as model to database.</returns>
        public ReceivedMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (isNull)
            {
                return null;
            }

            var jsonString = Encoding.UTF8.GetString(data).Trim('"').Replace("\\\"", "\"");
            Dictionary<string, object>? dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
            ReceivedMessage receivedMessage = new ()
            {
                CompanyId = long.Parse(dict["company_id"].ToString()),
                ConsumerUnity = dict["consumer_unity"].ToString(),
                Value = double.Parse(dict["value"].ToString()),
                Timestamp = DateTime.UnixEpoch.AddSeconds(Convert.ToDouble(dict["date"]))
            };
            return receivedMessage;
    }
    }
}
