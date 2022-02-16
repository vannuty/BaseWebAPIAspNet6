using Base.Domain.Intefaces.Services;
using Base.Infrastructure.Interfaces.Repositories;
using BaseLibrary.Entities;
using BaseLibrary.ViewModel;

namespace Base.Domain.Services
{
    public class ServiceTodo : IServiceTodo
    {
        private readonly IRepositoryTodo _repositoryTodo;

        public ServiceTodo(IRepositoryTodo repositoryTodo)
        {
            _repositoryTodo = repositoryTodo;
        }

        public async Task<Todo> Create(Todo todo)
        {
            return await _repositoryTodo.Create(todo);
        }

        public bool Delete(int id)
        {
            return _repositoryTodo.Delete(id);
        }

        public async Task<List<Todo>> GetAll()
        {
            return await _repositoryTodo.GetAll();
        }

        public async Task<Todo> GetById(int id)
        {
            return await _repositoryTodo.GetById(id);
        }

        public async Task<Todo> Update(TodoUpdateViewModel todoUpdate)
        {
            var todo = await _repositoryTodo.GetById(todoUpdate.Id);

            todo.Update(todoUpdate);

            return await _repositoryTodo.Update(todo);
        }
    }
}
