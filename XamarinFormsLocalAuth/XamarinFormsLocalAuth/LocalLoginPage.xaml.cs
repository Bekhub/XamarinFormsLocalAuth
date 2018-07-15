using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsLocalAuth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalLoginPage : ContentPage
    {
        private string pin = string.Empty;
        public LocalLoginPage()
        {
            InitializeComponent();

        }
        private void pinBtn_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (pin.Count() < 4)
            {
                pin += btn.Text;
            }
            else
                pin = "";
            switch (pin.Count())
            {
                case 0:
                    firstCircle.Active = false;
                    secondCircle.Active = false;
                    thirdCircle.Active = false;
                    lastCircle.Active = false;
                    break;
                case 1:
                    firstCircle.Active = true;
                    break;
                case 2:
                    secondCircle.Active = true;
                    break;
                case 3:
                    thirdCircle.Active = true;
                    break;
                case 4:
                    lastCircle.Active = true;
                    break;
                    //default:
            }
        }
        private async void faceIdBtn_Clicked(object sender, EventArgs e)
        {
            var result = await CrossFingerprint.Current.AuthenticateAsync("Prove you have fingers!");
            var f = await CrossFingerprint.Current.IsAvailableAsync();
            if (result.Authenticated)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                // not allowed to do secret stuff :(
            }
        }
    }
}