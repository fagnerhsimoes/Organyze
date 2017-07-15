using System.Threading.Tasks;
using Organyze.Models;
using Xamarin.Forms;
using Organyze.Helpers;
using System;
using System.Diagnostics;

namespace Organyze.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        public Command LoadCategoriasCommand { get; set; }
        public ObservableRangeCollection<Categoria> Categorias { get; set; }

        public CategoriaViewModel()
        {
            Title = "Categorias";
            Categorias = new ObservableRangeCollection<Categoria>();
            LoadCategoriasCommand = new Command(async () => await LoadAsync());
        }

        public override async Task LoadAsync()
        {
            /*  Categorias.Clear();
              var categorias = await DataCategoria.GetTagsAsync();
              Categorias.ReplaceRange(categorias);

              OnPropertyChanged(nameof(Categorias));*/

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Categorias.Clear();
                var categs = await DataCategoria.GetTagsAsync();
                Categorias.ReplaceRange(categs);

                OnPropertyChanged(nameof(Categorias)); 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
