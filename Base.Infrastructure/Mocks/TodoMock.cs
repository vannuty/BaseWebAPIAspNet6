using BaseLibrary.Entities;

namespace Base.Infrastructure.Mocks
{
    public class TodoMock
    {
        public static List<Todo> TodoMockValues()
        {
            List<Todo> mockValues = new List<Todo>();

            var i = 0;

            mockValues.Add(new Todo("Task 1", ++i));
            mockValues.Add(new Todo("Task 2", ++i));
            mockValues.Add(new Todo("Task 3", ++i));

            return mockValues;

        }
    }
}
