using System.Collections.Generic;
using Xamarin.Forms;
using Organyze.ViewModels;
using Organyze.Controls;
using System.Linq;
using Organyze.Interfaces;

namespace Organyze.Views
{
    public partial class CategoriaPage : ContentPage
    {
        CategoriaViewModel viewModel;
        public CategoriaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoriaViewModel();

            busca.TextChanged += Busca_TextChanged;
            CategoriaListView.ItemsSource = Listar();
        }

        async void OnCategoriaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categoria = args.SelectedItem as ICategoria;
            if (categoria == null)
                return;

          /*  await Navigation.PushAsync(new CategoriaDetailPage(new CategoriaDetailViewModel(categoria)));

            CategoriaListView.SelectedItem = null;*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadCategoriasCommand.Execute(null);
            CategoriaListView.ItemsSource = Listar(busca.Text);
        }

        private void Busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            CategoriaListView.ItemsSource = Listar(busca.Text);
        }

        public IEnumerable<Group<char, ICategoria>> Listar(string filtro = "")
        {
            IEnumerable<ICategoria> categoriasFiltrados = viewModel.Categorias;
            if (!string.IsNullOrEmpty(filtro))
                categoriasFiltrados = viewModel.Categorias.Where(l => (l.Nome.ToLower().Contains(filtro.ToLower())));

            return from categoria in categoriasFiltrados
                   orderby categoria.Nome
                   group categoria by categoria.Nome[0] into grupos
                   select new Group<char, ICategoria>(grupos.Key, grupos);
        }
    }
}

