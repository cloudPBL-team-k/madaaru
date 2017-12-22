using System;
using UserNotifications;

namespace Code_Scan_Test_by_ZXing.iOS {
    public class LocalNotificationCenterDelegate : UNUserNotificationCenterDelegate{
        //アクション
        public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler) {
            // Take action based on Action ID
            switch (response.ActionIdentifier) {
                case "reply":
                    //Replyボタンを押下した場合の動作を記述する
                    break;
                default:
                    // Take action based on identifier
                    if (response.IsDefaultAction) {
                        // デフォルトアクションを記述する
                    } else if (response.IsDismissAction) {
                        // キャンセルした場合
                    }
                    break;
            }

            // Inform caller it has been handled
            completionHandler();
        }
    }
}
