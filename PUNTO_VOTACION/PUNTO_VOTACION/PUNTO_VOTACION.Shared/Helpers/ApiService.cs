using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PUNTO_VOTACION.Models;



namespace PUNTO_VOTACION.Helpers
{
    public class ApiService
    {
        public static async Task<Response> RestoreAsync(LoginRequest model)
        {
            try
            {
                string request = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                HttpClientHandler handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };                

                HttpClient client = new HttpClient(handler)
                {
                    BaseAddress = new Uri("https://fpd2021uno.azurewebsites.net/")
                };

                HttpResponseMessage response = await client.PostAsync("api/Account/RecoverPassword", content);
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }        
    }
}