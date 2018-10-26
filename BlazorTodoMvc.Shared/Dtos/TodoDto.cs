using System;

namespace BlazorTodoMvc.Shared.Dtos
{
    public class TodoDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public bool Completed { get; set; }
    }
}
