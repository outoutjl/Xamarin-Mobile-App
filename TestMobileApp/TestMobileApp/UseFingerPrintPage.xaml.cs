using Plugin.Fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMobileApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UseFingerPrintPage : ContentPage
	{
		public UseFingerPrintPage ()
		{
			InitializeComponent ();
		}

        async private void BtnEnableFingerPrint_Clicked(object sender, EventArgs e)
        {
            //It doesn't support alternative authentication in Android.
            bool allowAlternativeAuthentication = false;

            var result = await CrossFingerprint.Current.IsAvailableAsync(allowAlternativeAuthentication);

            if (result)
            {
                string reason = "Please place your finger on the finger print scanner.";
                Plugin.Fingerprint.Abstractions.AuthenticationRequestConfiguration authenticationRequestConfiguration = new Plugin.Fingerprint.Abstractions.AuthenticationRequestConfiguration(reason);
                authenticationRequestConfiguration.AllowAlternativeAuthentication = true; //use default alternative authentication, which is the device passcode.

                try
                {
                    var auth = await CrossFingerprint.Current.AuthenticateAsync(authenticationRequestConfiguration);

                    if (auth.Authenticated)
                    {
                        await DisplayAlert("Good!", "Authentication success", "OK");
                    }
                    else if (auth.Status == Plugin.Fingerprint.Abstractions.FingerprintAuthenticationResultStatus.Canceled)
                    {
                        //If user cancel it, do nothing. Do not show anything, User can clcik on try later. 
                        await DisplayAlert("User clicked cancel", auth.Status.ToString(), "OK");
                    }
                    else if (auth.Status == Plugin.Fingerprint.Abstractions.FingerprintAuthenticationResultStatus.FallbackRequested)
                    {
                        await DisplayAlert("Fallback request", "User has the FP enroled. But request to fallback to alternative login method. ", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Oops!", "Authentication failed" + auth.ErrorMessage, "OK");
                    }
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Oops!", "Exception!" + ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Sorry", "your device does not support Touch ID.", "OK");
            }
        }
    }
}