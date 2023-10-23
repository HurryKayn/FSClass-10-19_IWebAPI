using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdottoController : ControllerBase
    {
        private IRepository repository;
        public ProdottoController(IRepository rep)
        {
            repository = rep;
        }

        [HttpGet]
        public IEnumerable<Prodotto> Get()
        {
            return repository.ElencoProdotti;
        }

        [HttpGet("{id}")]
        public ActionResult<Prodotto> Get(int id) 
        { 
            if (id <= 0)
            {
                return BadRequest("Deve essere passato un id valido");
            }
            return Ok(repository.GetProdottoById(id));
        }

        [HttpPost]
        public Prodotto Post([FromBody]Prodotto prodottoJson) 
        {
            var prodotto= new Prodotto();
            prodotto.Nome = prodottoJson.Nome;
            prodotto.UnitMisura= prodottoJson.UnitMisura;
            prodotto.Quantita= prodottoJson.Quantita;
            prodotto.Prezzo = prodottoJson.Prezzo;
            prodotto = repository.AddProdotto(prodotto);
            return prodotto;
        }
        [HttpPut]
        public Prodotto Put([FromBody] Prodotto prodotto)
        {
            return repository.UpdateProdotto(prodotto);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.DeleteProdotto(id);
        }
    }
}
