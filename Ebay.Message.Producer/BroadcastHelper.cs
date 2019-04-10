using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Ebay.Message.Utilities.Configuration.Model;
using Microsoft.Extensions.Options;

namespace Ebay.Message.BroadcastHelper
{
    public class BroadcastHelper : IBroadcastHelper
    {
        KafkaConfiguration kafkaConfiguration;

        Dictionary<string, object> config = new Dictionary<string, object>();

        public BroadcastHelper(IOptions<KafkaConfiguration> configuration)
        {
            this.kafkaConfiguration = configuration.Value;
            config.Add("bootstrap.servers", this.kafkaConfiguration.ServerName);
        }

        public bool SendMessage(string message)
        {
            try
            {
                using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
                {
                    string text = null;
                    producer.ProduceAsync(kafkaConfiguration.TopicName, null, text);
                    producer.Flush(100);
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
