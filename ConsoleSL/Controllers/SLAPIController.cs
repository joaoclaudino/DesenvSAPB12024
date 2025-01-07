using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using ConsoleSL.Models.SL;

namespace ConsoleSL.Controllers
{
    public class SLAPIController
    {
        private readonly string serviceLayerUrl = "https://localhost:50000/b1s/v1/";
        private string sessionId = string.Empty;
        //public static async Task SLAPIController()
        //{
        //    await LoginAsync();
        //}
        public async Task LoginAsync()
        {
            // Ignorar validação SSL
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            using (HttpClient client = new HttpClient(handler))
            {
                var loginUrl = $"{serviceLayerUrl}Login";

                var loginData = new
                {
                    UserName = "manager",   // Substitua pelo seu usuário SAP
                    Password = "x1234",     // Substitua pela sua senha
                    CompanyDB = "SBODemoBR"
                };

                var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(loginUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

                this.sessionId = loginResponse.SessionId;

                Console.WriteLine("Login realizado com sucesso. SessionId: " + sessionId);
            }
        }
        public async Task PostBusinessPartner(BusinessPartner businessPartner)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true;

            try
            {
                using (HttpClient client = new HttpClient(handler))
                {
                    // Serializa o objeto BusinessPartner para JSON
                    var json = JsonConvert.SerializeObject(businessPartner);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Configura o request POST
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{serviceLayerUrl}BusinessPartners");
                    request.Headers.Add("Cookie", $"B1SESSION={sessionId}");

                    // Define o conteúdo JSON
                    request.Content = content;

                    // Envia o request e captura a resposta
                    var response = await client.SendAsync(request);

                    // Se a resposta for um erro (status code 4xx ou 5xx)
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"Erro ao criar BusinessPartner. Código HTTP: {response.StatusCode}");
                        Console.WriteLine($"Resposta do erro: {errorContent}");
                    }
                    else
                    {
                        // Exibe a resposta em caso de sucesso
                        Console.WriteLine("BusinessPartner criado com sucesso!");
                        Console.WriteLine(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Tratar exceção de requisições HTTP
                Console.WriteLine($"Erro de requisição HTTP: {httpEx.Message}");
            }
            catch (TaskCanceledException taskEx)
            {
                // Tratar exceção de timeout ou cancelamento de tarefa
                Console.WriteLine($"Requisição cancelada ou tempo limite excedido: {taskEx.Message}");
            }
            catch (Exception ex)
            {
                // Tratar exceções gerais
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }
    }
   
}
