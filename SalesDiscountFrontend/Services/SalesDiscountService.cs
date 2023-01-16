using SaveMoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;

namespace SaveMoneyApp.Services
{
    public class SalesDiscountService : ISalesDiscountService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public List<SalesDiscount> Items { get; private set; }

        public SalesDiscountService()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<SalesDiscount>> GetTasksAsync()
        {
            Items = new List<SalesDiscount>();

            Uri uri = new Uri(string.Format(Constant.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<SalesDiscount>>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }


        public async Task DeleteTaskAsync(string id)
        {
            Uri uri = new Uri(string.Format(Constant.RestUrl,id));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public Task<SalesDiscount> CreateTaskAsync(SalesDiscount item)
        {
            throw new NotImplementedException();
        }

        public Task<SalesDiscount> UpdateTaskAsync(SalesDiscount item)
        {
            throw new NotImplementedException();
        }
    }
}
