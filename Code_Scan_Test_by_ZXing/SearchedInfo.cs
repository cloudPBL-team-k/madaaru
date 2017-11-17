using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Code_Scan_Test_by_ZXing
{
    [JsonArray]
    public class SearchedInfos{public List<SearchedInfo> JSON;}

    //Jsonをシリアライズするときに使うクラス
    [JsonObject("searchedinfo")]
    public class SearchedInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("jancode")]
        public string Jancode { get; set; }

        //CreatedDateはString型で良いのか不明
        [JsonProperty("created_at")]
        public DateTime CreateDate { get; set; }
        //同じくStringで良いか不明
        [JsonProperty("updated_at")]
        public DateTime UpdateDate { get; set; }
    }
}