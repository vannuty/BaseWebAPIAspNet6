using BaseLibrary.Entities;
using BaseLibrary.Interfaces;

namespace Base.Infrastructure.Interfaces.Repositories
{
    public interface IRepositoryTodo : IRepository<Todo>
    {
        Task<List<Todo>> GetAll();
        Task<Todo> GetById(int id);
        Task<Todo> Create(Todo todo);
        Task<Todo> Update(Todo todo);
        bool Delete(int id);
    }
}
