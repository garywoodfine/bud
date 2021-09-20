using Newtonsoft.Json;
namespace WorldBank
{

    public class Country
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("iso2Code")]
        public string Iso2Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public Adminregion Region { get; set; }

        [JsonProperty("adminregion")]
        public Adminregion Adminregion { get; set; }

        [JsonProperty("incomeLevel")]
        public Adminregion IncomeLevel { get; set; }

        [JsonProperty("lendingType")]
        public Adminregion LendingType { get; set; }

        [JsonProperty("capitalCity")]
        public string CapitalCity { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }

    

}
