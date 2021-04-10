using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stories.Domain.Model;

namespace Stories.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            List<User> users = new List<User>();
            User user = new User();
            user.PersonInfo = new PersonInfo();
            user.Address = (new Address { City = "Ikebukuro", Country = "Japan", Others = "池袋", Street = "" });
            user.LoginID = "testID";
            user.DisplayName = "Naofumi Aoyama";
            users.Add(user);
            var result = await Task.Run(() => users);
            return result;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>>GetTodoItem()
        //{
        //    return await _context.TodoItems
        //    .Select(x => ItemToDTO(x))
        //    .ToListAsync();
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetTodoItem(long id)
        //{
        //    var todoItem = await _context.TodoItems.FindAsync(id);

        //    if (UserAccount == null)
        //    {
        //        return NotFound();
        //    }

        //    return ItemToDTO(todoItem);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        //{
        //    if (id != todoItemDTO.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var todoItem = await _context.TodoItems.FindAsync(id);
        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    todoItem.Name = todoItemDTO.Name;
        //    todoItem.IsComplete = todoItemDTO.IsComplete;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        //    {
        //        return NotFound();
        //    }

        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        //{
        //    var todoItem = new TodoItem
        //    {
        //        IsComplete = todoItemDTO.IsComplete,
        //        Name = todoItemDTO.Name
        //    };

        //    _context.TodoItems.Add(todoItem);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(
        //        nameof(GetTodoItem),
        //        new { id = todoItem.Id },
        //        ItemToDTO(todoItem));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTodoItem(long id)
        //{
        //    var todoItem = await _context.TodoItems.FindAsync(id);

        //    if (todoItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoItems.Remove(todoItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TodoItemExists(long id) =>
        //     _context.TodoItems.Any(e => e.Id == id);

        //private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
        //    new TodoItemDTO
        //    {
        //        Id = todoItem.Id,
        //        Name = todoItem.Name,
        //        IsComplete = todoItem.IsComplete
        //    };

    }
}