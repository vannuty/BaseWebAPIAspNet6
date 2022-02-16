using Base.Domain.Intefaces.Services;
using BaseLibrary.Controllers;
using BaseLibrary.Entities;
using BaseLibrary.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : MainController
    {
        private readonly IServiceTodo _serviceTodo;

        public TodosController(IServiceTodo serviceTodo)
        {
            _serviceTodo = serviceTodo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _serviceTodo.GetAll();

            return CustomResponse(todos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var todo = await _serviceTodo.GetById(id);

            return todo == null ? NotFound() : CustomResponse(todo);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string description)
        {
            if (String.IsNullOrEmpty(description.Trim()))
            {
                AddError("Description must have a value");
                return CustomResponse();
            }
            var todo = new Todo(description);
            await _serviceTodo.Create(todo);
            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync([FromBody] TodoUpdateViewModel todoUpdate, int id)
        {
            if (!todoUpdate.GetValidationResult().IsValid)
            {
                return CustomResponse(todoUpdate.GetValidationResult());
            }

            var todo = await _serviceTodo.GetById(id);

            if (todo == null) return NotFound();

            if (todo.Id != id)
            {
                AddError("There was an error, please refresh and try again.");
                return CustomResponse();
            }

            todo = await _serviceTodo.Update(todoUpdate);

            return CustomResponse(todo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _serviceTodo.Delete(id);

            return CustomResponse();
        }
    }
}
