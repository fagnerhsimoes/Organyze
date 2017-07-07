using Organyze.Interfaces;

namespace Organyze.Models
{
    public class Projeto : BaseDataObject, IProjeto
    {
        string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { SetProperty(ref nome, value); }
        }

        string descricao = string.Empty;
        public string Descricao
        {
            get { return descricao; }
            set { SetProperty(ref descricao, value); }
        }

        string apagado = string.Empty;
        public string Apagado
        {
            get { return apagado; }
            set { SetProperty(ref apagado, value); }
        }

        string categoria = string.Empty;
        public string Categoria
        {
            get { return categoria; }
            set { SetProperty(ref categoria, value); }
        }

        string sincronizado = string.Empty;
        public string Sincronizado
        {
            get { return sincronizado; }
            set { SetProperty(ref sincronizado, value); }
        }

        bool ativo = true;
        public bool Ativo
        {
            get { return ativo; }
            set { SetProperty(ref ativo, value); }
        }

    }
}
