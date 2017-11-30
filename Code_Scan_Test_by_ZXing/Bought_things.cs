using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Code_Scan_Test_by_ZXing
{
    //買ったものを登録した後に返される次に買うべき日付
    [JsonObject("bought_things")]
    public class Bought_things
    {
        //この商品の次に買うべき日付
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("thing_id")]
        public int thing_id { get; set; }
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        [JsonProperty("num")]
        public int num { get; set; }
        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }
        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }    }
}



