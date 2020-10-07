using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Utils
{
    public class Moeda
    {
        [JsonPropertyName("USD")]
        public MoedaInfo MoedaInfo { get; set; }
        public float GetDolarValue()
        {
            float dolarHoje = 1;

            using (var client = new HttpClient())
            {
                // URL
                client.BaseAddress = new System.Uri("https://economia.awesomeapi.com.br/");
                // Headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Response                          // GET (action)
                HttpResponseMessage response = client.GetAsync("all/USD-BRL").Result;

                // Status Code
                if (response.IsSuccessStatusCode)
                {
                    // Body
                    string cotacao = response.Content.ReadAsStringAsync().Result;
                    Moeda convertido = JsonSerializer.Deserialize<Moeda>(cotacao);

                    dolarHoje = float.Parse(convertido.MoedaInfo.valor.Replace('.',','));
                }
            }

            return dolarHoje;
        }

    }
    public class MoedaInfo
    {
        [JsonPropertyName("high")]
        public string valor { get; set; }
    }
}
