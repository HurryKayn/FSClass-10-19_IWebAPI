namespace WebApi.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Prodotto> listaProdotti;
        public Repository()
        {
            listaProdotti  = new Dictionary<int, Prodotto>();
            int i = 0;
            {
                var prodotto = new Prodotto();
                prodotto.ProdottoId = ++i;
                prodotto.Nome = "Cacciavite Piatto";
                prodotto.UnitMisura = "NR";
                prodotto.Quantita = 10;
                prodotto.Prezzo = 6.78m;
                listaProdotti.Add(prodotto.ProdottoId, prodotto);
            }
            {
                var prodotto = new Prodotto();
                prodotto.ProdottoId = ++i;
                prodotto.Nome = "Cacciavite stella";
                prodotto.UnitMisura = "NR";
                prodotto.Quantita = 23;
                prodotto.Prezzo = 7.128m;
                listaProdotti.Add(prodotto.ProdottoId, prodotto);
            }
            {
                var prodotto = new Prodotto();
                prodotto.ProdottoId = ++i;
                prodotto.Nome = "Tenaglie";
                prodotto.UnitMisura = "NR";
                prodotto.Quantita = 120;
                prodotto.Prezzo = 12.6m;
                listaProdotti.Add(prodotto.ProdottoId, prodotto);
            }
            {
                var prodotto = new Prodotto();
                prodotto.ProdottoId = ++i;
                prodotto.Nome = "Pinza";
                prodotto.UnitMisura = "NR";
                prodotto.Quantita = 87;
                prodotto.Prezzo = 7.98m;
                listaProdotti.Add(prodotto.ProdottoId, prodotto);
            }
            {
                var prodotto = new Prodotto();
                prodotto.ProdottoId = ++i;
                prodotto.Nome = "Chiodi";
                prodotto.UnitMisura = "NR";
                prodotto.Quantita = 1400;
                prodotto.Prezzo = 0.48m;
                listaProdotti.Add(prodotto.ProdottoId, prodotto);
            }
        }
        public IEnumerable<Prodotto> ElencoProdotti
        {
            get
            {
                return listaProdotti.Values;
            }
        }

        public Prodotto AddProdotto(Prodotto prodotto)
        {
            if (prodotto.ProdottoId <= 0)
            {
                int key = listaProdotti.Count;
                while (listaProdotti.ContainsKey(key))
                 {
                    key++;
                }
                prodotto.ProdottoId = key;

            }
            
            listaProdotti.Add(prodotto.ProdottoId,prodotto);
            return prodotto;
        }

        public void DeleteProdotto(int id)
        {
            if (listaProdotti.ContainsKey(id)) listaProdotti.Remove(id);
        }

        public Prodotto GetProdottoById(int id)
        {
            if (listaProdotti.ContainsKey(id)) return listaProdotti[id];
            return null;
        }

        public Prodotto UpdateProdotto(Prodotto prodotto)
        {
            if (listaProdotti.ContainsKey(prodotto.ProdottoId))
            {
                listaProdotti[prodotto.ProdottoId] = prodotto;
                return prodotto;
            }
            return null;
        }
    }
}
