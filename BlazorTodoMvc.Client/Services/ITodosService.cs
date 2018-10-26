using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTodoMvc.Shared.Models;

namespace BlazorTodoMvc.Client.Services
{
    public interface ITodosService
    {
        Task DeleteAsync(TodoItem todo);
        Task<IList<TodoItem>> GetTodosAsync();
        Task PostTodoAsync(TodoItem todo);
        Task PutTodoAsync(TodoItem todo);
    }
}