using System;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Code_Scan_Test_by_ZXing
{
    public partial class Code_Scan_Test_by_ZXingPage : ContentPage
    {
        public Code_Scan_Test_by_ZXingPage()
        {
            InitializeComponent();
        }

        async void ScanButtonClicked(object sender, EventArgs s){
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };

            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                string jancode = result.Text;
                GetJson gj = new GetJson();


                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("Scan Done!", result.Text, "OK");
                });


                Device.BeginInvokeOnMainThread(async () =>
                {
                    string jsonString = await gj.GetItemJsonString(jancode);
                    await Navigation.PopAsync();
                    await DisplayAlert("Json生データ!新鮮!!", jsonString, "OK");
                });

                Device.BeginInvokeOnMainThread(async () =>
                {
                    SearchedInfo thingInfo = await gj.GetItemJson(jancode);
                    await Navigation.PopAsync();
                    await DisplayAlert("商品名じゃ!!", thingInfo.ThingName, "OK");

                    //それぞれの情報が次の形で呼び出せる
                    //thingInfo.ThingName
                    //thingInfo.ThingID
                    //thingInfo.Jancode
                    //thingInfo.CreateDate
                    //thingInfo.UpdateDate
                });
            };
        }
    }

}
