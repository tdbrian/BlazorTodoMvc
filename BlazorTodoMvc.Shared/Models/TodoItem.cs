
using System;

namespace BlazorTodoMvc.Shared.Models
{
    public class TodoItem
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool Completed { get; set; }

        public bool Editing { get; set; }
    }
}