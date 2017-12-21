using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class ItemInfoEditPage : ContentPage {
        public ItemInfoEditPage() {
            InitializeComponent();
        }

        public void CancelBtnClicked(object sender, EventArgs s){
            int itemNum = 1;
            if(int.TryParse(itemNumInput.Text, out itemNum)){//数値に変換できた場合itemNumに入る
                //ここに個数を更新してサーバに登録するしょりとかをかいていく
            }else{//Inputが数字以外
                DependencyService.Get<IMyFormsToast>().Show("Number ERROR: 数字を入力してください");
            }
        }
    }
}
