using ConsoleSL.Models.FakerAPI.Companie;
using ConsoleSL.Models.FakerAPI.Person;
using ConsoleSL.Models.FakerAPI.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSL.Controllers
{
    internal class FakerAPIController
    {
        public FakerAPIController() { }


        public async Task<PersonResponse?> ConsultaPersons()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fakerapi.it/api/v1/persons?_quantity=200&_locale=pt_BR");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode) { 
                string jsonResponse = await response.Content.ReadAsStringAsync();
                PersonResponse? objPersonResponse=JsonConvert.DeserializeObject<PersonResponse>(jsonResponse);
                return objPersonResponse;
            }
            else
            {
                return null;
            }
        }
        public async Task<CompanieResponse?> ConsultaCompanies()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fakerapi.it/api/v1/companies?_quantity=20&_locale=pt_BR");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                CompanieResponse? objCompanieResponse = JsonConvert.DeserializeObject<CompanieResponse>(jsonResponse);
                return objCompanieResponse;
            }
            else
            {
                return null;
            }
        }
        public async Task<ProductResponse?> ConsultaProduct()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://fakerapi.it/api/v1/products?_quantity=20&_locale=pt_BR");
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ProductResponse? objProductResponse = JsonConvert.DeserializeObject<ProductResponse>(jsonResponse);
                return objProductResponse;
            }
            else
            {
                return null;
            }
        }
    }
}
