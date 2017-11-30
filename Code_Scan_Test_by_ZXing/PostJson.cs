using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;
using Xamarin.Forms;
using System.Text;

namespace Code_Scan_Test_by_ZXing
{
    public class PostJson
    {
        //買う商品の情報オブジェクトBought_thingsを受け取ってJson化してPost後、
        //サーバーから帰ってくる[次にこの商品を買うべき日付]をオブジェクト化して変えす
        //public async Task<List<Next_buy_date>> PostBoughtThingsInfo(Bought_things bt)
        public async Task<Next_buy_date> PostBoughtThingsInfo(Bought_thing bt)
        {
            string serverUrl = "http://www.samidare.blue:3000";
            string APIUrl = "/bought_things";
            string reqUrl = $"{serverUrl}{APIUrl}";
            //string reqUrl = "http://www.samidare.blue:3000/bought_things";

            string jsonString = JsonConvert.SerializeObject(bt);

            HttpClient hc = new HttpClient();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await hc.PostAsync(reqUrl, content);

            //result string => {"next_buy_date": "1990-01-01"}
            string result = await response.Content.ReadAsStringAsync();
            //List<Next_buy_date> NBD = JsonConvert.DeserializeObject<List<Next_buy_date>>(result);
            Next_buy_date NBD = JsonConvert.DeserializeObject<Next_buy_date>(result);

            return NBD;
        }
    }
}
