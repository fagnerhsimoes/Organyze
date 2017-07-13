using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Organyze.Interfaces;
using Organyze.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Organyze.Helpers;
using Newtonsoft.Json;
using System.IO;

[assembly: Dependency(typeof(Organyze.Services.DataCategoria))]
[assembly: Dependency(typeof(Organyze.ViewModels.Services.IMessageService))]
[assembly: Dependency(typeof(Organyze.ViewModels.Services.INavigationService))]
namespace Organyze.Services
{
    public class DataCategoria : IDataCategoria<ICategoria>
    {
        bool isInitialized;
        List<ICategoria> categorias;
        ICategoria categoria;
        public Categoria Categoria { get; set; }

        private readonly ViewModels.Services.INavigationService _navigationService;
        private readonly ViewModels.Services.IMessageService _messageService;
        public DataCategoria()
        {
           // _realm = Realms.Realm.GetInstance();
            _navigationService = DependencyService.Get<ViewModels.Services.INavigationService>();
            _messageService = DependencyService.Get<ViewModels.Services.IMessageService>();
        }

        public async Task<IEnumerable<ICategoria>> GetCategoriasAsync()
        {
            return null;
        }

        public async Task<bool> AddCategoriaAsync(ICategoria Categoria)
        {
            await InitializeAsync();

           /* using (var transaction = _realm.BeginWrite())
            {
                categoria = _realm.CreateObject<RealmCategoria>();
                categoria.Nome = Categoria.Nome;
                categoria.Apagado = Categoria.Apagado;
                categoria.Sincronizado = Categoria.Sincronizado;
                categoria.Ativo = true;
                transaction.Commit();
            }*/

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateCategoriaAsync(ICategoria categoria)
        {
            await InitializeAsync();

            var _categoria = categorias.Where((ICategoria arg) => arg.Id == categoria.Id).FirstOrDefault();
            categorias.Remove(_categoria);
            categorias.Add(categoria);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCategoriaAsync(ICategoria categoria)
        {
            await InitializeAsync();

            var _categoria = categorias.Where((ICategoria arg) => arg.Id == categoria.Id).FirstOrDefault();
            categorias.Remove(_categoria);

            return await Task.FromResult(true);
        }

        public async Task<ICategoria> GetCategoriaAsync(string id)
        {
            await InitializeAsync();
            return await Task.FromResult(categorias.FirstOrDefault(s => s.Id == id));
        }

        public ICategoria GetNewCategoriaAsync()
        {
            Categoria = new Categoria();
            return Categoria;
        }

        public IEnumerable<ICategoria> GetCategorias(bool forceRefresh = false)
        {
            return null;
            //return _realm.All<RealmCategoria>().OrderByDescending(u => u.Nome);
        }

        //public async Task<List<ICategoria>>        BuscarCategoriasAsync()
        public async Task<IEnumerable<ICategoria>> BuscarCategoriasAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           var response = await httpClient.GetAsync($"{Constants.ApplicationURL}Categoria").ConfigureAwait(false);
            //var response = await httpClient.GetAsync($"{Constants.ApplicationURL}Categoria");

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<IEnumerable<Categoria>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }



        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            categorias = new List<ICategoria>();
           /* var categoriasrealm = _realm.All<RealmCategoria>().OrderByDescending(u => u.Nome);

            foreach (ICategoria categoria in categoriasrealm)
            {
                categorias.Add(categoria);
            }*/

            isInitialized = true;
        }
    }
}