using Microsoft.WindowsAzure.MobileServices;
using Organyze.Authentication;
using Organyze.Helpers;
using Organyze.iOS;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationService))]
namespace Organyze.iOS
{
    public class AuthenticationService : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client,
                                                          MobileServiceAuthenticationProvider provider,
                                                          IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                //TODO Log Erro
                throw;
            }
        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;
            while (root.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }
            return current;
        }
    }
}