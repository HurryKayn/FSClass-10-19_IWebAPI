

namespace WebApi.Models
{
    public interface IRepository
    {
        IEnumerable<Prodotto> ElencoProdotti { get; }
        Prodotto GetProdottoById(int id);
        Prodotto AddProdotto(Prodotto prodotto);
        Prodotto UpdateProdotto(Prodotto prodotto);
        void DeleteProdotto(int id);
    }
}
