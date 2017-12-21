using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
[assembly: Xamarin.Forms.Dependency(typeof(Code_Scan_Test_by_ZXing.iOS.NotificationService))]
namespace Code_Scan_Test_by_ZXing.iOS {
    public class NotificationService : INotificationService{
        UILocalNotification _notification;

        public void Regist() {
            // 許可をもらう通知タイプの種類を定義
            UIUserNotificationType types = UIUserNotificationType.Badge | // アイコンバッチ
                                           UIUserNotificationType.Sound | // サウンド
                                           UIUserNotificationType.Alert;  // テキスト
                                                                          // UIUserNotificationSettingsの生成
            UIUserNotificationSettings nSettings = UIUserNotificationSettings.GetSettingsForTypes(types, null);
            // アプリケーションに登録
            UIApplication.SharedApplication.RegisterUserNotificationSettings(nSettings);
        }

        public void On(string title, string body) {
            UIApplication.SharedApplication.InvokeOnMainThread(delegate
            {
                _notification = new UILocalNotification();
                _notification.Init();
                _notification.FireDate = NSDate.FromTimeIntervalSinceNow(10); //メッセージを通知する日時
                _notification.TimeZone = NSTimeZone.DefaultTimeZone;
                //_notification.RepeatInterval = NSCalendarUnit.Day; // 日々繰り返しする場合
                _notification.AlertTitle = title;
                _notification.AlertBody = body;
                _notification.AlertAction = @"Open"; //ダイアログで表示されたときのボタンの文言
                _notification.UserInfo = NSDictionary.FromObjectAndKey(new NSString("NotificationValue"), new NSString("NotificationKey"));
                _notification.SoundName = UILocalNotification.DefaultSoundName;
                // アイコン上に表示するバッジの数値
                UIApplication.SharedApplication.ApplicationIconBadgeNumber += 1;
                //通知を登録
                UIApplication.SharedApplication.ScheduleLocalNotification(_notification);
            });
        }
        public void Off() {
            UIApplication.SharedApplication.InvokeOnMainThread(delegate
            {
                //通知時に設定したUserInfoを元に通知情報をキャンセルする
                if (_notification != null &&
                    (NSString)(_notification.UserInfo.ObjectForKey(new NSString("NotificationKey"))) == new NSString("NotificationValue")) {
                    UIApplication.SharedApplication.CancelLocalNotification(_notification);
                }
            });
        }
    }
}
