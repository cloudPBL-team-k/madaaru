using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Code_Scan_Test_by_ZXing
{
    public class GetJson
    {
        public async Task<SearchedInfo> GetItemJson(string jancode)
        //public async Task<SearchedInfo> GetItemJson()
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string searchAPIUrl = "/things/search";
            //string jancode = "4903333111671";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            //SearchedInfo thingInfo = new SearchedInfo();
            HttpClient hc = new HttpClient();

            Task<string> stringAsync = hc.GetStringAsync(reqUrl);
            string jsonString = await stringAsync;

            SearchedInfo thingInfo = JsonConvert.DeserializeObject<SearchedInfo>(jsonString);
            return thingInfo;
        }


        public async Task<List<SearchedInfo>> GetItemInfo(string jancode)
        //public async Task<SearchedInfo> GetItemJson()
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string searchAPIUrl = "/things/search";
            //string jancode = "4903333111671";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            //SearchedInfo thingInfo = new SearchedInfo();
            HttpClient hc = new HttpClient();
            string jsonString = await hc.GetStringAsync(reqUrl);

            List<SearchedInfo> list = JsonConvert.DeserializeObject<List<SearchedInfo>>(jsonString);
            return list;
            //SearchedInfo thingInfo = JsonConvert.DeserializeObject<List<SearchedInfos>>(jsonString);
            //SearchedInfo thingInfo = JsonConvert.DeserializeObject<SearchedInfo>(jsonString);
            //return thingInfo;
        }

        //jsonの生データを表示するデバッグ用
        public async Task<string> GetItemJsonString(string jancode)
        //public async Task<SearchedInfo> GetItemJson()
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string searchAPIUrl = "/things/search";
            //string jancode = "4903333111671";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            //SearchedInfo thingInfo = new SearchedInfo();
            HttpClient hc = new HttpClient();

            Task<string> stringAsync = hc.GetStringAsync(reqUrl);
            string jsonString = await stringAsync;

            return jsonString;
        }
    }
}
