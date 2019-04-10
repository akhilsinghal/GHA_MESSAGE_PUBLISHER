using System;
using System.Collections.Generic;
using System.Text;

namespace Ebay.Message.Utilities.Configuration.Model
{
    public class KafkaConfiguration
    {
        public string ServerName { get; set; }

        public string TopicName { get; set; }
    }
}
