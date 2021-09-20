using Newtonsoft.Json;

namespace WorldBank
{
    public class Adminregion
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso2code")]
        public string Iso2Code { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}