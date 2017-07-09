using System.Collections.Generic;
using Xamarin.Forms;
using Organyze.ViewModels;
using Organyze.Controls;
using System.Linq;
using Organyze.Interfaces;
using Organyze.Models;

namespace Organyze.Views
{
    public partial class DepartamentoPage : ContentPage
    {
        DepartamentoViewModel viewModel;
        public DepartamentoPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new DepartamentoViewModel();

            busca.TextChanged += Busca_TextChanged;
            DepartamentosListView.ItemsSource = Listar();
        }

        async void OnDepartamentoSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var departamento = args.SelectedItem as IDepartamento;
            if (departamento == null)
                return;

            await Navigation.PushAsync(new DepartamentoDetailPage(new DepartamentoDetailViewModel(departamento)));

            DepartamentosListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadDepartamentosCommand.Execute(null);
            DepartamentosListView.ItemsSource = Listar(busca.Text);
        }

        private void Busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            DepartamentosListView.ItemsSource = Listar(busca.Text);
        }

        public IEnumerable<Group<char, IDepartamento>> Listar(string filtro = "")
        {
            IEnumerable<IDepartamento> departamentosFiltrados = viewModel.Departamentos;
            if (!string.IsNullOrEmpty(filtro))
                departamentosFiltrados = viewModel.Departamentos.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower())));

            return from departamento in departamentosFiltrados
                   orderby departamento.Nome
                   group departamento by departamento.Nome[0] into grupos
                   select new Group<char, IDepartamento>(grupos.Key, grupos);
        }
    }
}

