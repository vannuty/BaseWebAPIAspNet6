using Base.Domain.Services;
using Base.Infrastructure.Interfaces.Repositories;
using Base.Infrastructure.Mocks;
using FluentAssertions;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Base.Tests.Domain.Services
{
    public class ServiceTodoTest
    {
        [Fact]
        public async Task TodoService_GetAll_MustRetornMockValues()
        {
            // Arrange
            var repositoryTodo = new Mock<IRepositoryTodo>();
            repositoryTodo.Setup(x => x.GetAll()).Returns(Task.FromResult(TodoMock.TodoMockValues()));

            var serviceTodo = new ServiceTodo(repositoryTodo.Object);

            // Act
            var listTodos = await serviceTodo.GetAll();

            // Assert
            listTodos.Should().NotBeEmpty();
            listTodos.Should().HaveCount(TodoMock.TodoMockValues().Count());
            repositoryTodo.Verify(x => x.GetAll(), Times.Once);
        }


    }
}
