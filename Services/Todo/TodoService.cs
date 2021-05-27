using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PracticalTest.Services.Todo
{
    class TodoService : ITodoService
    {
        private string url = "https://jsonplaceholder.typicode.com/todos/";

        private readonly HttpClient _client;

        private readonly ILogger<TodoService> _logger;

        public TodoService(HttpClient httpClient, ILogger<TodoService> logger)
        {
            this._client = httpClient;
            this._logger = logger;
        }

        public async Task<Models.Todo> GetTodo(int id = 1)
        {
            try
            {
                var _url = url + id;

                var response = await _client.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    Models.Todo todo = JsonConvert.DeserializeObject<Models.Todo>(await response.Content.ReadAsStringAsync());
                    return todo;
                }

                _logger.LogInformation($"Status code from response {response.StatusCode.ToString()}");
                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }

        }
    }
}
