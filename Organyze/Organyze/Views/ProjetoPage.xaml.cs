using System;
using Xamarin.Forms;
using Organyze.ViewModels;
using Organyze.Models;


namespace Organyze.Views
{
    public partial class ProjetoPage : ContentPage
    {
        ProjetoViewModel viewModel;

        public ProjetoPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProjetoViewModel();
        }

        async void OnProjetoSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var projeto = args.SelectedItem as Projeto;
            if (projeto == null)
                return;

            await Navigation.PushAsync(new ProjetoDetailPage(new ProjetoDetailViewModel(projeto)));

            ProjetoListView.SelectedItem = null;
        }

        async void AddProjeto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjetoPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Projetos.Count == 0)
                viewModel.LoadProjetoCommand.Execute(null);
        }
    }
}
