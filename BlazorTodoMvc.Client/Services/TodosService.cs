using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorTodoMvc.Shared.Models;
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

        public async Task<IList<TodoItem>> GetTodosAsync()
        {
            return await _http.GetJsonAsync<List<TodoItem>>(TODOS_PATH);
        }

        public async Task PostTodoAsync(TodoItem todo)
        {
            await _http.PostJsonAsync(TODOS_PATH, todo);
        }

        public async Task PutTodoAsync(TodoItem todo)
        {
            await _http.PutJsonAsync($"{TODOS_PATH}/{todo.Id}", todo);
        }

        public async Task DeleteAsync(TodoItem todo)
        {
            await _http.DeleteAsync($"{TODOS_PATH}/{todo.Id}");
        }
    }
}
