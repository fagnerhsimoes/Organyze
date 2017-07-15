using Xamarin.Forms;
using Organyze.ViewModels;
using Organyze.Models;

namespace Organyze.Views
{
    public partial class CategoriaPage : ContentPage
    {
        CategoriaViewModel viewModel;
        public CategoriaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CategoriaViewModel();
        }

        async void OnCategoriaSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categoria = args.SelectedItem as Categoria;
            if (categoria == null)
                return;

          /*  await Navigation.PushAsync(new CategoriaDetailPage(new CategoriaDetailViewModel(categoria)));

            CategoriaListView.SelectedItem = null;*/
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categorias.Count == 0)
                viewModel.LoadAsync();
        }

    }
}

