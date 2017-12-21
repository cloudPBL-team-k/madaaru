using Xamarin.Forms;
using System.Threading;

namespace Code_Scan_Test_by_ZXing {
    public partial class App : Application {

        public static bool IsUserLoggedIn { get; set; }


        public App() {
            //InitializeComponent();
            //MainPage = new Code_Scan_Test_by_ZXingPage();
            //画面遷移履歴の管理、戻るボタン対処をNavigationPageクラスが自動的に行う

            if(!IsUserLoggedIn){
                //Loginページへ
                //通知設定をiOSに登録
                DependencyService.Get<INotificationService>().Regist();

                MainPage = new NavigationPage(new LoginPage());
            }else{
                MainPage = new NavigationPage(new Code_Scan_Test_by_ZXingPage());
            }
        
        
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

    //DependencyServiceから利用する
    public interface INotificationService {
        //iOS用の登録
        void Regist();
        //通知する
        void On(string title, string body);
        //通知を解除する
        void Off();
    }
}
