using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnUseFingerPrint_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UseFingerPrintPage());
        }
    }
}
