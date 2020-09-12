using ConsulTI.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsulTI.Services
{
    public class FazendaDeGadoServices
    {

        public async Task<IEnumerable<FazendaDeGado>> GetFazendasAsync()
        {

            using (var httpClient = new HttpClient())
            {

                httpClient.BaseAddress = new Uri("http://tst.sportibrasil.com.br");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("/Services/CategoriaOficialService.svc/ObterPorEstadoFazenda/2");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var jsonObject = JObject.Parse(jsonString);

                    var list = JsonConvert.DeserializeObject<IEnumerable<FazendaDeGado>>(jsonObject["ObterPorEstadoFazendaResult"].ToString());
                    return list;

                }
                else
                {
                    List<FazendaDeGado> list = new List<FazendaDeGado>();
                    var erro = new FazendaDeGado { Nome = "Nenhuma fazenda de gado encontrada." };
                    list.Add(erro);
                    return list;
                }
            }
        }
    }
}
