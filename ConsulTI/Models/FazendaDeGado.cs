using Newtonsoft.Json;
using System.ComponentModel;

namespace ConsulTI.Models
{
    public class FazendaDeGado
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("Sexo")]
        public string Sexo { get; set; }

        [JsonProperty("UF")]
        public string UF { get; set; }

        [DisplayName("Valor Máximo")]
        [JsonProperty("ValorMaximo")]
        public int ValorMaximo { get; set; }

        [DisplayName("Valor Mínimo")]
        [JsonProperty("ValorMinimo")]
        public int ValorMinimo { get; set; }
    }
}
