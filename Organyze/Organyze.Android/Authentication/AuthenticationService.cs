using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Organyze.Droid.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using Organyze.Authentication;
using Organyze.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationService))]
namespace Organyze.Droid.Authentication
{
    public class AuthenticationService : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client,
                                                          MobileServiceAuthenticationProvider provider,
                                                          IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception)
            {
                //TODO: LogError
                return null;
            }
        }
    }
}