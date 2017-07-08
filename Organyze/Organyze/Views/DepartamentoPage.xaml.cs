using System.Collections.Generic;
using Xamarin.Forms;
using Organyze.ViewModels;
using Organyze.Controls;
using System.Linq;
using Organyze.Interfaces;
using Organyze.Models;
using Organyze.Services;
using System;
using System.Threading.Tasks;

namespace Organyze.Views
{
    public partial class DepartamentoPage : ContentPage
    {
        DepartamentoManager manager;
        DepartamentoViewModel viewModel;
        public DepartamentoPage()
        {
            InitializeComponent();
          //  BindingContext = viewModel = new DepartamentoViewModel();

         //   busca.TextChanged += Busca_TextChanged;
            // DepartamentosListView.ItemsSource = Listar();

            manager = DepartamentoManager.DefaultManager;
            if (manager.IsOfflineEnabled &&
                (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone))
            {
                var syncButton = new Button
                {
                    Text = "Sincronizar Departamentos",
                    HeightRequest = 30
                };
                syncButton.Clicked += OnSyncDepartamentos;

                buttonsPanel.Children.Add(syncButton);
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
            await RefreshDepartamentos(true, syncDepartamentos: true);
        }

        async void OnDepartamentoSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var departamento = args.SelectedItem as Departamento;
            if (departamento == null)
                return;

            await Navigation.PushAsync(new DepartamentoDetailPage(new DepartamentoDetailViewModel(departamento)));

            DepartamentosListView.SelectedItem = null;
        }

       /* protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDepartamentosCommand.Execute(null);
          //  DepartamentosListView.ItemsSource = Listar(busca.Text);
        }*/

        private void Busca_TextChanged(object sender, TextChangedEventArgs e)
        {
         //   DepartamentosListView.ItemsSource = Listar(busca.Text);
        }

        /* public IEnumerable<Group<char, IDepartamento>> Listar(string filtro = "")
         {
             IEnumerable<IDepartamento> departamentosFiltrados = viewModel.Departamentos;
             if (!string.IsNullOrEmpty(filtro))
                 departamentosFiltrados = viewModel.Departamentos.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower())));

             return from departamento in departamentosFiltrados
                    orderby departamento.Ativo, departamento.Nome
                    group departamento by departamento.Nome[0] into grupos
                    select new Group<char, IDepartamento>(grupos.Key, grupos);
         }*/


        public async void OnSyncDepartamentos(object sender, EventArgs e)
        {
            await RefreshDepartamentos(true, true);
        }

        private async Task RefreshDepartamentos(bool showActivityIndicator, bool syncDepartamentos)
        {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
            {
                DepartamentosListView.ItemsSource = await manager.GetDepartamentosAsync(syncDepartamentos);
            }
        }

        private class ActivityIndicatorScope : IDisposable
        {
            private bool showIndicator;
            private ActivityIndicator indicator;
            private Task indicatorDelay;

            public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
            {
                this.indicator = indicator;
                this.showIndicator = showIndicator;

                if (showIndicator)
                {
                    indicatorDelay = Task.Delay(2000);
                    SetIndicatorActivity(true);
                }
                else
                {
                    indicatorDelay = Task.FromResult(0);
                }
            }

            private void SetIndicatorActivity(bool isActive)
            {
                this.indicator.IsVisible = isActive;
                this.indicator.IsRunning = isActive;
            }

            public void Dispose()
            {
                if (showIndicator)
                {
                    indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
        }

        // Data methods
        async Task AddDepartamento(Departamento departament)
        {
            await manager.SaveTaskAsync(departament);
            DepartamentosListView.ItemsSource = await manager.GetDepartamentosAsync();
        }

        async Task CompleteItem(Departamento departament)
        {
            departament.Apagado = true;
            await manager.SaveTaskAsync(departament);
            DepartamentosListView.ItemsSource = await manager.GetDepartamentosAsync();
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            var depart = new Departamento { Nome = newItemName.Text };
            await AddDepartamento(depart);

            newItemName.Text = string.Empty;
            newItemName.Unfocus();
        }

        // Event handlers
        public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var depart = e.SelectedItem as Departamento;
            if (Device.OS != TargetPlatform.iOS && depart != null)
            {
                // Not iOS - the swipe-to-delete is discoverable there
                if (Device.OS == TargetPlatform.Android)
                {
                    await DisplayAlert(depart.Nome, "Clique para apagar o Depatamento " + depart.Nome, "Got it!");
                }
                else
                {
                    // Windows, not all platforms support the Context Actions yet
                    if (await DisplayAlert("Mark deleted?", "Do you wish to delete " + depart.Nome + "?", "Apagar", "Cancelar"))
                    {
                        await CompleteItem(depart);
                    }
                }
            }

            // prevents background getting highlighted
            DepartamentosListView.SelectedItem = null;
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#context
        public async void OnComplete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var depart = mi.CommandParameter as Departamento;
            await CompleteItem(depart);
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshDepartamentos(false, true);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

    }
}

