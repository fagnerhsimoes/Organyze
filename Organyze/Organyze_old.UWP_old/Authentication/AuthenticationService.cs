using Microsoft.WindowsAzure.MobileServices;
using Organyze.Helpers;
using Organyze.UWP;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Organyze.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticationService))]
namespace Organyze.UWP

{
    public class AuthenticationService : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client,
                                                        MobileServiceAuthenticationProvider provider,
                                                        IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);
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
    }
}