using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTodoMvc.Client.Models;

namespace BlazorTodoMvc.Client.Services
{
    public interface ITodosService
    {
        Task DeleteAsync(TodoViewModel todo);
        Task<IList<TodoViewModel>> GetTodosAsync();
        Task PostTodoAsync(TodoViewModel todo);
        Task PutTodoAsync(TodoViewModel todo);
    }
}