using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTodoMvc.Client.Models;
using Microsoft.AspNetCore.Blazor;

namespace BlazorTodoMvc.Client.Services
{
    public class TodosService : ITodosService
    {
        private const string TODOS_PATH = "api/todos";
        private readonly HttpClient _http;

        public TodosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IList<TodoViewModel>> GetTodosAsync()
        {
            return await _http.GetJsonAsync<List<TodoViewModel>>(TODOS_PATH);
        }

        public async Task PostTodoAsync(TodoViewModel todo)
        {
            await _http.PostJsonAsync(TODOS_PATH, todo);
        }

        public async Task PutTodoAsync(TodoViewModel todo)
        {
            await _http.PutJsonAsync($"{TODOS_PATH}/{todo.Id}", todo);
        }

        public async Task DeleteAsync(TodoViewModel todo)
        {
            await _http.DeleteAsync($"{TODOS_PATH}/{todo.Id}");
        }
    }
}
