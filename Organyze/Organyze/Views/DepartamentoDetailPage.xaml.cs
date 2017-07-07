using Xamarin.Forms;
using Organyze.ViewModels;

namespace Organyze.Views
{
    public partial class DepartamentoDetailPage : ContentPage
    {
        DepartamentoDetailViewModel viewModel;

        public DepartamentoDetailPage()
        {
            InitializeComponent();
        }

        public DepartamentoDetailPage(DepartamentoDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}
