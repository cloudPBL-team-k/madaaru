using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class DevPage : ContentPage {
        public DevPage() {
            InitializeComponent();
        }


        private string scanedcode;

        async void ScanButtonClicked(object sender, EventArgs s) {
            var scanPage = new ZXingScannerPage() {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;
                string jancode = result.Text;
                Device.BeginInvokeOnMainThread(async () => {
                    scanedcode = result.Text;
                    await Navigation.PopAsync();
                    await DisplayAlert("Scan Done!", result.Text, "OK");
                });
            };
        }

        //for debug
        void ShowJancodeButtonClicked(object sender, EventArgs s) {
            GetJson gj = new GetJson();
            Device.BeginInvokeOnMainThread(async () => {
                string jsonString = await gj.GetItemJsonString(scanedcode);
                await Navigation.PopAsync();
                await DisplayAlert("Json生データ!", jsonString, "OK");
            });
        }

        void ShowItemNameButtonClicked(object sender, EventArgs s) {
            GetJson gj = new GetJson();
            Device.BeginInvokeOnMainThread(async () => {
                string jsonString = await gj.GetItemJsonString(scanedcode);
                if (jsonString != "null") {
                    //List<SearchedInfo> thingInfo = await gj.GetItemInfo(scanedcode);
                    SearchedInfo thingInfo = await gj.GetItemInfo(scanedcode);
                    await Navigation.PopAsync();
                    await DisplayAlert("商品名!!", thingInfo.Name, "OK");
                } else {//json null
                    DependencyService.Get<IMyFormsToast>().Show("該当の商品情報がありません!");
                }

            });
        }


        void ToastDevBtnClicked(object sender, EventArgs s) {
            DependencyService.Get<IMyFormsToast>().Show("Toast Dev Page Test!");
        }


        void ToastBtnClicked(object sender, EventArgs s) {
            DependencyService.Get<IMyFormsToast>().Show("Toast Test!");
        }

        void Toast2BtnClicked(object sender, EventArgs s) {
            DependencyService.Get<IMyFormsToast>().Show("Toast 222 Test!");
        }


        void BackMainPageBtnClicked(object sender, EventArgs s){
            Navigation.PopAsync(true);
        }
    }
}
