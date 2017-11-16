using System;
using Newtonsoft.Json;

namespace Code_Scan_Test_by_ZXing
{
    //Jsonをシリアライズするときに使うクラス
    public class SearchedInfo
    {
        [JsonProperty("id")]
        public int ThingID { get; set; }
        [JsonProperty("name")]
        public string ThingName { get; set; }
        [JsonProperty("jancode")]
        public int Jancode { get; set; }

        //CreatedDateはString型で良いのか不明
        [JsonProperty("created_at")]
        public string CreateDate { get; set; }
        //同じくStringで良いか不明
        [JsonProperty("updated_at")]
        public string UpdateDate { get; set; }
    }
}

