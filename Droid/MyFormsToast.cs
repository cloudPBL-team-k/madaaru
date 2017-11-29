using System;
using Android.Widget;
//using Xamarin.Forms;


[assembly: Xamarin.Forms.Dependency(typeof(Code_Scan_Test_by_ZXing.Droid.MyFormsToast))]
namespace Code_Scan_Test_by_ZXing.Droid
{
    class MyFormsToast : IMyFormsToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}
