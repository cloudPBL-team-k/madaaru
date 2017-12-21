using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Collections.Generic;
using ZXing;
using System.Threading.Tasks;

namespace Code_Scan_Test_by_ZXing {
    public partial class Code_Scan_Test_by_ZXingPage : ContentPage {
        public Code_Scan_Test_by_ZXingPage() {
            InitializeComponent();
        }

        private string scanedcode;


        async void BoughtThisItemBtnClicked(object sender, EventArgs s) {
            var scanPage = new ZXingScannerPage() {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) => {
                scanedcode = result.Text;
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () => {
                    await Navigation.PopAsync();

                    DependencyService.Get<IMyFormsToast>().Show("LightWeghtTest:" + scanedcode);
                    GetJson gj = new GetJson();
                    string jsonString = await gj.GetItemJsonString(scanedcode);
                    if (jsonString != "null") {
                        SearchedInfo thingInfo = gj.GetItemObjectFromJson(jsonString);
                        //userIdはとりあえず1の人固定
                        int userId = 1;
                        int itemId = thingInfo.Id;
                        //個数はとりあえず1個固定
                        int itemNum = 1;

                        //購入品情報を作成
                        Bought_thing bt = new Bought_thing();
                        bt.user_id = userId;
                        bt.thing_id = itemId;
                        bt.num = itemNum;

                        PostJson pj = new PostJson();
                        //Postして購入済みリストに追加、次の購入日を取得
                        Next_buy_date nextBuyDate = await pj.PostBoughtThingInfo(bt);

                        DependencyService.Get<IMyFormsToast>().Show("次の購入日を取得:" + nextBuyDate.next_buy_date);

                        //消耗品リスト作成
                        Bought_expendable be = new Bought_expendable();
                        be.user_id = userId;
                        be.thing_id = thingInfo.Id;
                        be.limit = nextBuyDate.next_buy_date;
                        //Postして消耗品リストに登録
                        Expendables postedEx = await pj.PostExpendablesInfo(be);

                        DependencyService.Get<IMyFormsToast>().Show("消耗品リストに登録しました: " + postedEx.created_at);
                    } else {//json null
                        DependencyService.Get<IMyFormsToast>().Show("該当の商品情報がありません!");
                    }

                });
            };
        }


        void ShowAllItemsBtnClicked(object sender, EventArgs s) {
            DependencyService.Get<IMyFormsToast>().Show("テストトースト");
        }

        void DevPageBtnClicked(object sender, EventArgs s){
            Navigation.PushAsync(new DevPage(), true);
        }

        async void LogOutBtnClicked(object sender, EventArgs s) {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
