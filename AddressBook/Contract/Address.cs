using Newtonsoft.Json;

namespace AddressBook.Contract
{
    public class Address
    {
        [JsonProperty("firstname")]
        public string firstname { get; set; }
        [JsonProperty("lastname")]
        public string lastname { get; set; }
        [JsonProperty("streetaddress")]
        public string streetaddress { get; set; }
        [JsonProperty("city")]
        public string city { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
    }
}
