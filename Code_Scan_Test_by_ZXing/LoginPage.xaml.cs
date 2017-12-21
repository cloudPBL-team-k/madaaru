using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
        }


        //private string userId = "";

        public void LoginBtnClicked(object sender, EventArgs s) {
            if (idInput.Text.Length != 0 && passInput.Text.Length != 0) {
                //userId = idInput.Text;
                if (idInput.Text.Length >= 3 && passInput.Text.Length >= 5) {//id>=3,pass>=5
                    DependencyService.Get<IMyFormsToast>().Show("Login ERROR: Login機能は実装されていません！");
                } else {
                    DependencyService.Get<IMyFormsToast>().Show("Login ERROR: idは3文字以上、Passは５文字以上入力してください");
                }
            } else{//id = null, pass = null
                DependencyService.Get<IMyFormsToast>().Show("Login ERROR: id,passを入力してください");
            }
        }

        void BackMainPageBtnClicked(object sender, EventArgs s) {
            Navigation.PopAsync(true);
        }

    }
}
