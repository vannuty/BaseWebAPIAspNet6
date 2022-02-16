using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;


namespace Base.Infrastructure.Mocks
{
    public static class MockHander
    {
        public static void HandleMocks(this ModelBuilder builder)
        {
            builder.Entity<Todo>().HasData(TodoMock.TodoMockValues());
        }
    }
}
