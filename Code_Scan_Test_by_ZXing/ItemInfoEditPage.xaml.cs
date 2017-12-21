using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class ItemInfoEditPage : ContentPage {

        private string thisjancode = "1";

        //public ItemInfoEditPage(Bought_thing bt){
        //    InitializeComponent();
        //    //商品名、個数を載せたかったがBought_thingsとSearchedInfoを持ってこれなかったのでできない
        //    itemNumInput.Text = bt.num.ToString();
        //}



        public ItemInfoEditPage(string jancode) {
            InitializeComponent();
            thisjancode = jancode;
        }

        async void OkBtnClicked(object sender, EventArgs s) {
            //DependencyService.Get<IMyFormsToast>().Show("thisjancode:" + thisjancode);
            GetJson gj = new GetJson();
            string jsonString = await gj.GetItemJsonString(thisjancode);
            if (jsonString != "null") {
                SearchedInfo thingInfo = gj.GetItemObjectFromJson(jsonString);
                //userIdはとりあえず1の人固定
                int userId = 1;
                int itemId = thingInfo.Id;
                //個数は1で初期化、入力を読み込む
                int itemNum = 1;


                if (int.TryParse(itemNumInput.Text, out itemNum)) {//数値に変換できた場合itemNumに入る

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

                } else {//Inputが数字以外
                    DependencyService.Get<IMyFormsToast>().Show("Number ERROR: 数字を入力してください");
                }
            } else {//json null
                DependencyService.Get<IMyFormsToast>().Show("スキャンに失敗したか、該当の商品情報がありません!");
            }
            //戻る
            await Navigation.PopAsync();
        }

        void CancelBtnClicked(object sender, EventArgs s) {
            Navigation.PopAsync();
        }
    }
}
