using Base.Infrastructure.Context;
using Base.Infrastructure.Repositories.Interfaces;
using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infrastructure.Repositories
{
    public class RepositoryTodo : IRepositoryTodo
    {
        private readonly DataContext _context;

        public RepositoryTodo(DataContext context)
        {
            _context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public bool Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(todo => todo.Id == id);

            if (todo != null)
            {
                todo.Deleted = true;

                _context.Entry(todo).State = EntityState.Modified;
                return _context.SaveChanges() > 0;
            }

            return false;

        }

        public async Task<List<Todo>> GetAll()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<Todo> GetById(int id)
        {
            var todo = await _context.Todos.Where(x => x.Id == id).FirstOrDefaultAsync();

            return todo;

        }

        public async Task<Todo> Update(Todo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return todo;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
