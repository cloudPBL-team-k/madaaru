using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Code_Scan_Test_by_ZXing
{
    //買ったものを登録するときにPOSTして使うJson
    [JsonObject("bought_things")]
    public class Bought_things {
        //ものを買ったユーザーのid
        [JsonProperty("user_id")]
        public int user_id { get; set; }
        //物のid
        [JsonProperty("thing_id")]
        public int thing_id { get; set; }
        //個数
        [JsonProperty("num")]
        public int num { get; set; }
    }
}