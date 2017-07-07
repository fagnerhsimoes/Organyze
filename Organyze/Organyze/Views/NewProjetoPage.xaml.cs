using System;
using Xamarin.Forms;
using Organyze.Models;


namespace Organyze.Views
{
    public partial class NewProjetoPage : ContentPage
    {
        public Projeto Projeto { get; set; }

        public NewProjetoPage()
        {
            InitializeComponent();

            Projeto = new Projeto
            {
                Nome = "Nome do Projeto",
                Descricao = "Descrição do Projeto"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Adicionar", Projeto);
            await Navigation.PopAsync();
        }

    }
}