using BaseLibrary.Entities;
using BaseLibrary.ViewModel;

namespace Base.Domain.Services.Intefaces
{
    public interface IServiceTodo
    {
        Task<List<Todo>> GetAll();
        Task<Todo> GetById(int id);
        Task<Todo> Create(Todo todo);
        Task<Todo> Update(TodoUpdateViewModel todoUpdate);
        bool Delete(int id);
    }
}
