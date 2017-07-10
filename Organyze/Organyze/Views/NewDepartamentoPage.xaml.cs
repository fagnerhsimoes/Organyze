using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Organyze.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDepartamentoPage : ContentPage
    {
        public NewDepartamentoPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.NewDepartamentoViewModel();
        }
    }
}