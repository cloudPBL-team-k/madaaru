using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Code_Scan_Test_by_ZXing
{
    public partial class SABpage : ContentPage
    {
        public SABpage()
        {
            InitializeComponent();
        }

        async void ShowAllItemsButtonClicked(object sender, EventArgs s)
        {
            GetJson gj = new GetJson();
            int userId = 1;
            string jsonString = await gj.GetExpendablesInfo(userId);

            if (jsonString != "null")
            {
                List<Expendables> expendablesInfo = gj.GetAllItemsObjectFromJson(jsonString);
                //Dictionary<string, string> sab = new Dictionary<string, string>();

                //for (int i = expendablesInfo.Count - 10; i < expendablesInfo.Count; i++)
                //{
                //    sab.Add(expendablesInfo[i].name, expendablesInfo[i].limit);
                //}
                for (int n = 0; n < 10;n++){
                    DependencyService.Get<IMyFormsToast>().Show(expendablesInfo[n].name);
                }
            }
            else
            {//json null
                DependencyService.Get<IMyFormsToast>().Show("商品情報はありません!");
            }
        }

        void BackBtnClicked(object sender, EventArgs s)
        {
            Navigation.PopAsync(true);
        }
    }
}
