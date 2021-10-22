using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkAutoMapperVSManualMapper
{
    public class SampleObjectDto
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("guid")]
        public Guid Guid { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("textData")]
        public string TextData { get; set; }
        
    }
}
