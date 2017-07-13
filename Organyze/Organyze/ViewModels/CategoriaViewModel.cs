using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Organyze.Helpers;
using Xamarin.Forms;
using Organyze.Interfaces;
using System.Collections.Generic;
using Organyze.Models;

namespace Organyze.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ICategoria> Categorias { get; set; }
        public Command LoadCategoriasCommand { get; set; }
        Task<IEnumerable<ICategoria>> categorias;
        private readonly Services.IMessageService _messageService;
        private readonly Services.INavigationService _navigationService;
        public CategoriaViewModel()
        {
            Title = "Categorias";
            Categorias = new ObservableRangeCollection<ICategoria>();
            LoadCategoriasCommand = new Command(async () => await ExecuteLoadCategoriasCommand());
            AddCategoriaCommand = new Command(ExecuteAddCategoria);

            _messageService = DependencyService.Get<Services.IMessageService>();
            _navigationService = DependencyService.Get<Services.INavigationService>();
        }

        public Command AddCategoriaCommand
        {
            get;
            set;
        }

        private async void ExecuteAddCategoria()
        {
            await _navigationService.NavigationToNewCategoria();
        }

        private async Task ExecuteLoadCategoriasCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
             
            try
            {
                /* Categorias.Clear();
                 var categorias    = DataCategoria.GetCategorias();
                 //var categoriasApi = await ApiCategoria.GetCategoriasAsync();
                 Categorias.AddRange(categorias);
                 //Categorias.AddRange(categoriasApi);*/

                Categorias.Clear();
                categorias = DataCategoria.BuscarCategoriasAsync();

               // categorias = await DataCategoria.BuscarCategoriasAsync();

               /* var tags = await _monkeyHubApiService.GetTagsAsync();

                System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", tags.Count);
                Tags.Clear();
                foreach (var tag in tags)
                {
                    Tags.Add(tag);
                }

                OnPropertyChanged(nameof(Tags));*/

                //Categorias.ReplaceRange(categorias);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await _messageService.msgErroAsync("Não foi possível carregar as categorias");
            }
            finally 
            {
                IsBusy = false;
            }
        }
    }
}