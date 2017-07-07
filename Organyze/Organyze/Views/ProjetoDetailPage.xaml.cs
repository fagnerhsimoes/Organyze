using Xamarin.Forms;
using Organyze.ViewModels;


namespace Organyze.Views
{
    public partial class ProjetoDetailPage : ContentPage
    {
        ProjetoDetailViewModel viewModel;

        public ProjetoDetailPage()
        {
            InitializeComponent();
        }

        public ProjetoDetailPage(ProjetoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
