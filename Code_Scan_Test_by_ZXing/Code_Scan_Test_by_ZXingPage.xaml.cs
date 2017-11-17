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

        private string scanedcode = null;

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
                Device.BeginInvokeOnMainThread(async () =>
                {
                    scanedcode = result.Text;
                    await Navigation.PopAsync();
                    await DisplayAlert("Scan Done!", result.Text, "OK");
                });
            };
        }

        //async void ShowJancodeButtonClicked(object sender, EventArgs s)
        void ShowJancodeButtonClicked(object sender, EventArgs s)
        {
                GetJson gj = new GetJson();

                Device.BeginInvokeOnMainThread(async () =>
                {
                    string jsonString = await gj.GetItemJsonString(scanedcode);
                    await Navigation.PopAsync();
                    await DisplayAlert("Json生データ!新鮮!!", jsonString, "OK");
                });
        }
        //async void ShowItemCodeButtonClicked(object sender, EventArgs s)
        void ShowItemNameButtonClicked(object sender, EventArgs s)
        {
            GetJson gj = new GetJson();
            Device.BeginInvokeOnMainThread(async () =>
            {
                List<SearchedInfo> thingInfo = await gj.GetItemInfo(scanedcode);
                await Navigation.PopAsync();
                string itemName = thingInfo[0].Name;
                string itemName2 = thingInfo[0].Jancode;

                await DisplayAlert("商品名!!", thingInfo[0].Name, "OK");
                //await DisplayAlert("商品名!!", thingInfo.Name, "OK");
                //それぞれの情報が次の形で呼び出せる
                //thingInfo.ID
                //thingInfo.Name
                //thingInfo.Jancode
                //thingInfo.CreateDate
                //thingInfo.UpdateDate
            });
        }



    }

}
