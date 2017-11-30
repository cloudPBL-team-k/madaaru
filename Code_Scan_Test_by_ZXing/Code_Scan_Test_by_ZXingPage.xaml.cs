﻿using System;
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
                    await DisplayAlert("Json生データ!", jsonString, "OK");
                });
        }

        void ShowItemNameButtonClicked(object sender, EventArgs s)
        {
            GetJson gj = new GetJson();
            Device.BeginInvokeOnMainThread(async () =>
            {
                string jsonString = await gj.GetItemJsonString(scanedcode);
                if(jsonString != "null"){
                    //List<SearchedInfo> thingInfo = await gj.GetItemInfo(scanedcode);
                    SearchedInfo thingInfo = await gj.GetItemInfo(scanedcode);
                    await Navigation.PopAsync();
                    await DisplayAlert("商品名!!", thingInfo.Name, "OK");
                }else{//json null
                    DependencyService.Get<IMyFormsToast>().Show("該当の商品情報がありません!");
                }

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
                    string jsonString = await gj.GetItemJsonString(scanedcode);
                    if (jsonString != "null")
                    {
                        //userIdはとりあえず1の人固定
                        int userId = 1;
                        //int itemId = thingInfo[0].Id;
                        int itemId = thingInfo.Id;
                        //個数はとりあえず1個固定
                        int itemNum = 1;

                        Bought_thing bt = new Bought_thing();
                        bt.user_id = userId;
                        bt.thing_id = itemId;
                        bt.num = itemNum;

                        PostJson pj = new PostJson();
                        //List<Next_buy_date> nextBuyDate = await pj.PostBoughtThingsInfo(bt);
                        Next_buy_date nextBuyDate = await pj.PostBoughtThingsInfo(bt);
                        await Navigation.PopAsync();
                        await DisplayAlert("次の購入日", nextBuyDate.next_buy_date, "OK");
                    }
                    else
                    {//json null
                        DependencyService.Get<IMyFormsToast>().Show("該当の商品情報がありません!");
                    }
                });
            };
        }

        async void ShowAllItemBtnClicked(object sender, EventArgs s)
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
                    string jsonString = await gj.GetItemJsonString(scanedcode);
                    if (jsonString != "null")
                    {
                        //List<SearchedInfo> thingInfo = await gj.GetItemInfo(result.Text);
                        SearchedInfo thingInfo = await gj.GetItemInfo(result.Text);
                        await Navigation.PopAsync();
                        await DisplayAlert("商品名!!", thingInfo.Name, "OK");
                        //userIdはとりあえず1の人固定
                        int userId = 1;
                        //int itemId = thingInfo[0].Id;
                        int itemId = thingInfo.Id;
                        //個数はとりあえず1個固定
                        int itemNum = 1;

                        Bought_thing bt = new Bought_thing();
                        bt.user_id = userId;
                        bt.thing_id = itemId;
                        bt.num = itemNum;

                        PostJson pj = new PostJson();
                        //List<Next_buy_date> nextBuyDate = await pj.PostBoughtThingsInfo(bt);
                        Next_buy_date nextBuyDate = await pj.PostBoughtThingsInfo(bt);
                        await Navigation.PopAsync();
                    }
                    }
                    else
                    {//json null
                        DependencyService.Get<IMyFormsToast>().Show("登録された商品はありません!");
                    }
                });
            };
        }

      
        void ToastBtnClicked(object sender, EventArgs s){
            DependencyService.Get<IMyFormsToast>().Show("Toast Test!");
        }

    }
}
