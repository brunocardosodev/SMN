using DataAccess.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClienteDataAccess
    {
        public async Task<Cliente> GetDadosPJ(string cnpj)
        {
            try
            {
                const string url = ("https://www.receitaws.com.br/v1/cnpj/");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = string.Empty;
                    HttpResponseMessage response = await client.GetAsync(cnpj);
                    if (response.IsSuccessStatusCode)
                    {
                        content = await response.Content.ReadAsStringAsync();
                    }

                    var jsonObject = JObject.Parse(content);

                    var nmEmpresa = jsonObject["nome"];
                    var nmFantasia = jsonObject["fantasia"];
                    var cliente = new Cliente(cnpj, nmEmpresa.ToString(), nmFantasia.ToString());

                    return cliente;
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
