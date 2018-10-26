using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BlazorTodoMvc.Shared.Models;

namespace BlazorTodoMvc.Server.Todos
{
    [Route("api/todos")]
    public class TodosController : Controller
    {
        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return TodosRepo.GetTodos();
        }

        [HttpPost]
        public void Post([FromBody] TodoItem todo)
        {
            var todos = TodosRepo.GetTodos();
            todos.Add(todo);
            TodosRepo.SaveTodos(todos);
        }

        [HttpPut("{id}")]
        public void Put([FromRoute]Guid id, [FromBody] TodoItem todo)
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