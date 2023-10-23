using APIRequest.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json.Serialization;

namespace APIRequest.Controllers
{
    public class HomeController : Controller
    {
        string portaServer = "7204";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Prodotto>  lista = new List<Prodotto>();
            using (var httpClient = new HttpClient())
            {
                 
                using (var response = await httpClient.GetAsync($"https://localhost:{portaServer}/api/prodotto"))
                {
                    string rispostaAPI=await response.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<Prodotto>>(rispostaAPI);
                }
            }
            return View(lista);
        }

        [HttpGet]
        public ViewResult GetProdotto()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> GetProdotto(int id)
        {
            Prodotto  prodotto =new Prodotto();
            using (var httpClient = new HttpClient())
            {
                using (var resp = await httpClient.GetAsync($"https://localhost:{portaServer}/api/prodotto/"+id))
                {
                    if (resp.StatusCode==System.Net.HttpStatusCode.OK)
                    { 
                        string rispostaAPI = await resp.Content.ReadAsStringAsync();
                        prodotto = JsonConvert.DeserializeObject<Prodotto>(rispostaAPI);
                    }
                }
            }

            return View(prodotto);
        }

        //----------------------------------------------
        [HttpGet]
        public ViewResult AddProdotto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProdotto(Prodotto model)
        {
            
            Prodotto prodotto = new Prodotto();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");

                using (var response = await httpClient.PostAsync($"https://localhost:{portaServer}/api/prodotto", content))
                {
                    string apiResponse =await response.Content.ReadAsStringAsync();
                    prodotto =JsonConvert.DeserializeObject<Prodotto>(apiResponse);
                }
            }

            return View(prodotto);
        }
        //---------------------------------------------- Update Prodotto
        [HttpGet]
        public async Task<IActionResult> UpdateProdotto(int id)
        {
            Prodotto prodotto = new Prodotto();
            using(var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync($"https://localhost:{portaServer}/api/prodotto/" + id))
                using (var response = await httpClient.GetAsync($"https://localhost:{portaServer}/api/prodotto/"+id))
                {
                    string rispostaAPI = await response.Content.ReadAsStringAsync();
                    prodotto = JsonConvert.DeserializeObject<Prodotto>(rispostaAPI);
                }
            }
            return View(prodotto);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProdotto(Prodotto model)
        {

            Prodotto prodotto = new Prodotto();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync($"https://localhost:{portaServer}/api/prodotto", content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("index");
                    }

                    else
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        prodotto = JsonConvert.DeserializeObject<Prodotto>(apiResponse);

                    }
                }
            }

            return View(prodotto);
        }


        //---------------------------------------------- Delete Prodotto
        [HttpPost]
        public async Task<IActionResult> DeleteProdotto(int id) 
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync($"https://localhost:{portaServer}/api/prodotto/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("index");
        }




        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
