using System;
using System.Collections.Generic;
using System.IO;
using BlazorTodoMvc.Shared.Models;
using Newtonsoft.Json;

namespace BlazorTodoMvc.Server.Todos
{
    public class TodosRepo
    {
        public static string TodosDirectory => Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "blazor-todos");

        public static string TodosFile => Path.Join(TodosDirectory, "my-todos.txt");

        private static void CreateTodosFile()
        {
            Directory.CreateDirectory(TodosDirectory);
            if (File.Exists(TodosFile)) return;
            File.Create(TodosFile);
            Console.WriteLine($"Created file at {TodosFile}");
        }

        public static List<TodoItem> GetTodos()
        {
            CreateTodosFile();
            var todosText = File.ReadAllText(TodosFile);
            var todos = JsonConvert.DeserializeObject<List<TodoItem>>(todosText);
            return todos ?? new List<TodoItem>();
        }

        public static void SaveTodos(IEnumerable<TodoItem> todos)
        {
            CreateTodosFile();
            var todosText = JsonConvert.SerializeObject(todos);
            File.WriteAllText(TodosFile, todosText);
            Console.WriteLine($"Saved todos at {TodosFile}");
        }
    }
}
