﻿using Microsoft.WindowsAzure.MobileServices;
using Organyze.Authentication;
using Organyze.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Organyze.Services.AzureService))]
namespace Organyze.Services
{
    public class AzureService
    {
        static readonly string AppUrl = @"https://organyze.azurewebsites.net/";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Não foi possível efetuar login, tente novamente.", "OK");
                });
                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }
            return true;
        }
    }
}
