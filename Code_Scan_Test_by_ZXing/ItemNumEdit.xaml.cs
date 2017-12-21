using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class ItemNumEdit : ContentPage {
        private string thisjancode = "1";

        public ItemNumEdit(string jancode) {
            InitializeComponent();
            thisjancode = jancode;
        }


        //async void OKBtnClicked(object sender, EventArgs s) {
        //    GetJson gj = new GetJson();
        //    string jsonString = await gj.GetItemJsonString(thisjancode);
        //    if (jsonString != "null") {
        //        SearchedInfo thingInfo = gj.GetItemObjectFromJson(jsonString);
        //        //userIdはとりあえず1の人固定
        //        int userId = 1;
        //        int itemId = thingInfo.Id;
        //        //個数は1で初期化、入力を読み込む
        //        int itemNum = 1;

        //        if (int.TryParse(itemNumInput.Text, out itemNum)) {//数値に変換できた場合itemNumに入る
        //            //購入品情報を作成
        //            Bought_thing bt = new Bought_thing();
        //            bt.user_id = userId;
        //            bt.thing_id = itemId;
        //            bt.num = itemNum;

        //            //Navigation.PushAsync(new ItemInfoEditPage(bt), true);

        //            //戻る
        //            await Navigation.PopAsync();
        //        } else {
        //            DependencyService.Get<IMyFormsToast>().Show("数値を入力してください");
        //            itemNumInput.Text = string.Empty;
        //        }
        //    }
        //}
    }
}
