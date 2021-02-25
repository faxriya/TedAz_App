using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MHM.TedAzApp.Models.BusinessModels
{
    public class CommandModel
    {
        [JsonProperty(PropertyName = "cmdId")]
        public int CmdId { get; set; }

        [JsonProperty(PropertyName = "topicId")]
        public int TopicId { get; set; }

        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty(PropertyName = "dateStart")]
        public string DateStart { get; set; }

        [JsonProperty(PropertyName = "dateEnd")]
        public string DateEnd { get; set; }
    }
}
