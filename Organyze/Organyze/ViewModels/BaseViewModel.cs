﻿using Organyze.Helpers;
using Organyze.Interfaces;
using Organyze.Models;
using Organyze.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Organyze.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /* public IDataCliente<ICliente> DataCliente => DependencyService.Get<IDataCliente<ICliente>>();
         public IDataItem<IItem> DataItem => DependencyService.Get<IDataItem<IItem>>();
         public IDataFuncionario<IFuncionario> DataFuncionario => DependencyService.Get<IDataFuncionario<IFuncionario>>();
         public IDataOrdemServico<IOrdemServico> DataOrdemServico => DependencyService.Get<IDataOrdemServico<IOrdemServico>>();
         public IDataCategoria<ICategoria> ApiCategoria => DependencyService.Get<IDataCategoria<ICategoria>>();
         public IDataDepartamento<IDepartamento> DataDepartamento => DependencyService.Get<IDataDepartamento<IDepartamento>>();*/
        public IDataCategoria<Categoria>        DataCategoria    => DependencyService.Get<IDataCategoria<Categoria>>();
        public IDataDepartamento<IDepartamento> DataDepartamento => DependencyService.Get<IDataDepartamento<IDepartamento>>();
        public IDataProjeto<Projeto>            DataProjeto      => DependencyService.Get<IDataProjeto<Projeto>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }
    }
}

