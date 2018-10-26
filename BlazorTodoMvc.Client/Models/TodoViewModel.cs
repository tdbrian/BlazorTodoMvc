using BlazorTodoMvc.Shared.Dtos;

namespace BlazorTodoMvc.Client.Models
{
    public class TodoViewModel : TodoDto
    {
        public bool Editing { get; set; }
    }
}
