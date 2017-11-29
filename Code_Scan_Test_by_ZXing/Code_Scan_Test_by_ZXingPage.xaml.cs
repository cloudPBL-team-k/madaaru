using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;

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

        //for debug
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
                //それぞれの情報が次の形で呼び出せる
                //thingInfo[0].ID
                //thingInfo[0].Name
                //thingInfo[0].Jancode
                //thingInfo[0].CreateDate
                //thingInfo[0].UpdateDate
            });
        }

        async void BoughtThisItemBtnClicked(object sender, EventArgs s)
        {
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    GetJson gj = new GetJson();
                    List<SearchedInfo> thingInfo = await gj.GetItemInfo(result.Text);
                    string itemName = thingInfo[0].Name;

                    if(thingInfo[0].Name != "null"){
                        await Navigation.PopAsync();
                        await DisplayAlert("Scan Done!", thingInfo[0].Name, "OK");
                    }else{//null
                        await Navigation.PopAsync();
                        await DisplayAlert("Scan Done!", "商品の名前がありませんでした", "OK");
                    }

  
                });
            };
        }

        void ToastBtnClicked(object sender, EventArgs s){
            DependencyService.Get<IMyFormsToast>().Show("Toast Test!");
        }

    }
}
