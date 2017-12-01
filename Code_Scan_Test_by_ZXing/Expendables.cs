using System;
using Newtonsoft.Json;

namespace Code_Scan_Test_by_ZXing
{
    //消耗品のオブジェクト
    [JsonObject("expendables")]
    public class Expendables
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("thing_id")]
        public int thing_id { get; set; }
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [JsonProperty("limit")]
        public string limit { get; set; }
        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }
        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }
    }
}
