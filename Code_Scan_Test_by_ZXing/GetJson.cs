using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public class GetJson {
        //public async Task<List<SearchedInfo>> GetItemInfo(string jancode)
        public async Task<SearchedInfo> GetItemInfo(string jancode) {
            //string serverUrl = "http://www.samidare.blue:3000";
            string serverUrl = ServerInfo.GetUrl();
            string searchAPIUrl = "/things/search";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            SearchedInfo thingInfo = new SearchedInfo();
            HttpClient hc = new HttpClient();
            //Jsonを取得できなかった時の例外のハンドリング
            try {
                string jsonString = await hc.GetStringAsync(reqUrl);
                thingInfo = JsonConvert.DeserializeObject<SearchedInfo>(jsonString);
            } catch (HttpRequestException e) {
                DependencyService.Get<IMyFormsToast>().Show("HttpClient ERROR: " + e.Message);
            }
            return thingInfo;
        }

        //Jsonを受け取ってオブジェクトに変換
        public SearchedInfo GetItemObjectFromJson(string jsonString) {
            SearchedInfo thingInfo = JsonConvert.DeserializeObject<SearchedInfo>(jsonString);
            return thingInfo;
        }

        public async Task<List<Bought_things>> GetAllItemsInfo(int user_id)
        //public async Task<Bought_things> GetAllItemsInfo(int user_id)
        {
            //string serverUrl = "http://www.samidare.blue:3000";
            string serverUrl = ServerInfo.GetUrl();
            string searchAPIUrl = "/bought_things";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?user_id={user_id}";
            //string finalUrl = "http://www.samidare.blue:3000/bought_things?user_id=1";

            HttpClient hc = new HttpClient();
            string jsonString = await hc.GetStringAsync(reqUrl);
            List<Bought_things> thingsInfo = JsonConvert.DeserializeObject<List<Bought_things>>(jsonString);
            //Bought_things thingsInfo = JsonConvert.DeserializeObject<Bought_things>(jsonString);
            return thingsInfo;
        }

        public async Task<List<Expendables>> GetExpendablesInfo(int user_id)
        //public async Task<Expendables> GetExpendablesInfo(int user_id)
        {
            //string serverUrl = "http://www.samidare.blue:3000";
            string serverUrl = ServerInfo.GetUrl();
            string searchAPIUrl = "/expendables.json";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?user_id={user_id}";
            //string finalUrl = "http://www.samidare.blue:3000/expendables.json?user_id=1";

            HttpClient hc = new HttpClient();

            string jsonString = await hc.GetStringAsync(reqUrl);
            List<Expendables> expendablesInfo = JsonConvert.DeserializeObject<List<Expendables>>(jsonString);
            //Expendables expendablesInfo = JsonConvert.DeserializeObject<Expendables>(jsonString);
            return expendablesInfo;

        }

        //jsonの生データを表示するデバッグ用
        public async Task<string> GetItemJsonString(string jancode) {
            //string serverUrl = "http://www.samidare.blue:3000";
            string serverUrl = ServerInfo.GetUrl();
            string searchAPIUrl = "/things/search";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            HttpClient hc = new HttpClient();

            string jsonString = await hc.GetStringAsync(reqUrl);

            return jsonString;
        }


        public async Task<Expendables> GetExpendablesObject(int user_id) {
            //string serverUrl = "http://www.samidare.blue:3000";
            string serverUrl = ServerInfo.GetUrl();
            string searchAPIUrl = "/expendables.json";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?=user_id={user_id}";
            //string finalUrl = "http://www.samidare.blue:3000/expendables.json";

            HttpClient hc = new HttpClient();
            string jsonString = await hc.GetStringAsync(reqUrl);
            //List<SearchedInfo> thingInfo = JsonConvert.DeserializeObject<List<SearchedInfo>>(jsonString);
            Expendables expendables = JsonConvert.DeserializeObject<Expendables>(jsonString);
            return expendables;
        }
    }
}
