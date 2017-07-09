using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Organyze.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(Organyze.Services.DataProjeto))]
namespace Organyze.Services
{
    public class DataProjeto : IDataProjeto<Projeto>
    {
        bool isInitialized;
        List<Projeto> projetos;
        static string Desc = "Aplicativo desenvolvido com objetivo de auxilizar na Gestão de Tarefas e Ordem de serviços da organização/empresa." +
                             "Este aplicativo está escrito em C # e APIs nativas usando a Plataforma Xamarin." +
                             "Ele compartilha código com o iOS, Android e Windows";
        public async Task<bool> AddProjetoAsync(Projeto projeto)
        {
            await InitializeAsync();

            projetos.Add(projeto);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateProjetoAsync(Projeto projeto)
        {
            await InitializeAsync();

          /*  var _projeto = projetos.Where((Projeto arg) => arg.Id == projeto.Id).FirstOrDefault();
            projetos.Remove(_projeto);
            projetos.Add(projeto);*/

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProjetoAsync(Projeto projeto)
        {
            await InitializeAsync();

           /* var _projeto = projetos.Where((Projeto arg) => arg.Id == projeto.Id).FirstOrDefault();
            projetos.Remove(_projeto);*/

            return await Task.FromResult(true);
        }

        public async Task<Projeto> GetProjetoAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(projetos.FirstOrDefault());

            //  return await Task.FromResult(projetos.FirstOrDefault(s => s.Id == id));
        }

        public IEnumerable<Projeto> GetProjetos(bool forceRefresh = false)
        {
            InitializeAsync();

            return projetos;
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

          /*  projetos = new List<Projeto>();
            var _projetos = new List<Projeto>
            {
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto1", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto2", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto3", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto4", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto5", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto6", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto7", Descricao = Desc},
                new Projeto { Id = Guid.NewGuid().ToString(), Nome = "Projeto8", Descricao = Desc},
            };

            foreach (Projeto projeto in _projetos)
            {
                projetos.Add(projeto);
            }*/

            isInitialized = true;
        }
    }
}
