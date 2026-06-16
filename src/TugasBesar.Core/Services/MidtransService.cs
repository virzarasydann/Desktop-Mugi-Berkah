using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TugasBesar.Core.DTO.Response;
using TugasBesar.Core.Services.Interfaces;

namespace TugasBesar.Core.Services
{
    public class MidtransService : IMidtransService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public MidtransService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<MidtransResponseDTO> CreateTransactionAsync(string orderId, int grossAmount, string customerName)
        {
            var serverKey = _configuration["Midtrans:ServerKey"];
            var isProductionStr = _configuration["Midtrans:IsProduction"];
            var isProduction = !string.IsNullOrEmpty(isProductionStr) && isProductionStr.ToLower() == "true";

            var url = isProduction 
                ? "https://app.midtrans.com/snap/v1/transactions" 
                : "https://app.sandbox.midtrans.com/snap/v1/transactions";

            var authString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{serverKey}:"));

            var requestBody = new
            {
                transaction_details = new
                {
                    order_id = orderId,
                    gross_amount = grossAmount
                },
                customer_details = new
                {
                    first_name = customerName
                }
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authString);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.PostAsync(url, jsonContent);
            
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Gagal menghubungi Midtrans: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var midtransResponse = JsonSerializer.Deserialize<MidtransResponseDTO>(responseContent);

            return midtransResponse;
        }
    }
}
