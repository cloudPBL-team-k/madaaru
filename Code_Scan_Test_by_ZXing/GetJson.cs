using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing
{
    public class GetJson
    {
        public async Task<List<SearchedInfo>> GetItemInfo(string jancode)
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string searchAPIUrl = "/things/search";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            HttpClient hc = new HttpClient();
            //string jsonString;
            //Jsonを取得できなかった時の例外のハンドリング
            //try{
            //    jsonString = await hc.GetStringAsync(reqUrl);
            //    List<SearchedInfo> thingInfo = JsonConvert.DeserializeObject<List<SearchedInfo>>(jsonString);
            //    //return thingInfo;
            //}catch(HttpRequestException e){
            //    DependencyService.Get<IMyFormsToast>().Show("ERROR NULL JSON RECEIVED");
            //}

            string jsonString = await hc.GetStringAsync(reqUrl);
            List<SearchedInfo> thingInfo = JsonConvert.DeserializeObject<List<SearchedInfo>>(jsonString);
            return thingInfo;
        
        }

        //jsonの生データを表示するデバッグ用
        public async Task<string> GetItemJsonString(string jancode)
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string searchAPIUrl = "/things/search";
            string reqUrl = $"{serverUrl}{searchAPIUrl}?jancode={jancode}";
            //string finalUrl = "http://www.samidare.blue:3000/things/search?jancode=4903333111671";

            HttpClient hc = new HttpClient();

            string jsonString = await hc.GetStringAsync(reqUrl);

            return jsonString;
        }
    }
}
