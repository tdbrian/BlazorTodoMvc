using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlazorTodoMvc.Shared.Dtos;

namespace BlazorTodoMvc.Server.Todos
{
    [Route("api/todos")]
    public class TodosController : Controller
    {
        [HttpGet]
        public IEnumerable<TodoDto> Get()
        {
            return TodosRepo.GetTodos();
        }

        [HttpPost]
        public void Post([FromBody] TodoDto todo)
        {
            var todos = TodosRepo.GetTodos();
            todos.Add(todo);
            TodosRepo.SaveTodos(todos);
        }

        [HttpPut("{id}")]
        public void Put([FromRoute]Guid id, [FromBody] TodoDto todo)
        {
            var todos = TodosRepo.GetTodos();
            todos[todos.FindIndex(ind => ind.Id == todo.Id)] = todo;
            TodosRepo.SaveTodos(todos);
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute]Guid id)
        {
            var todos = TodosRepo.GetTodos();
            var todo = todos.Find(ind => ind.Id == id);
            todos.Remove(todo);
            TodosRepo.SaveTodos(todos);
        }
    }
}
