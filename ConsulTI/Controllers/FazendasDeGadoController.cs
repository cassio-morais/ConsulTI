using ConsulTI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsulTI.Controllers
{

    public class FazendasDeGadoController : Controller
    {

        public async Task<IActionResult> Index()
        {

            var httpClient = new HttpClient { BaseAddress = new Uri("http://tst.sportibrasil.com.br") };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync("/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(jsonString);

                var list = JsonConvert.DeserializeObject<List<FazendaDeGado>>(jsonObject["ObterPorEstadoFazendaResult"].ToString());
                return View(list);

            }
            else
            {
                return RedirectToAction(nameof(Error), new ErrorViewModel { Error = response.ReasonPhrase });
            }

        }

        public IActionResult Error(ErrorViewModel err)
        {
            return View(err);
        }
    }
}
