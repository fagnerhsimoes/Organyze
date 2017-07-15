using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Organyze.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(Organyze.Services.DataCategoria))]
namespace Organyze.Services
{
    public class DataCategoria : IDataCategoria<Categoria>
    {
        private const string BaseUrl = "http://localhost:55560/api/";
        List<Categoria> categorias;

        public async Task<IEnumerable<Categoria>> GetTagsAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}Categoria").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Categoria>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

    }
}
