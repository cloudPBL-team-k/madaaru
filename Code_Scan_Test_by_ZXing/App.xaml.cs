using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing {
    public partial class App : Application {
        public App() {
            //InitializeComponent();
            //MainPage = new Code_Scan_Test_by_ZXingPage();
            //画面遷移履歴の管理、戻るボタン対処をNavigationPageクラスが自動的に行う
            MainPage = new NavigationPage(new Code_Scan_Test_by_ZXingPage());
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }

    //「依存処理」のインターフェース定義
    //インターフェイスの定義はIから始まる習慣があるっぽい
    public interface IMyFormsToast {
        void Show(string message);
    }
}
