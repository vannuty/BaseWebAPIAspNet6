using BaseLibrary.Entities;
using BaseLibrary.Exceptions;
using BaseLibrary.ViewModel;
using FluentAssertions;
using Xunit;

namespace Base.Tests.Domain.Entities
{
    public class TodoTests
    {
        [Fact]
        public void CreateNewTodo_WithValidDescription_MustBeValid()
        {
            // Arrange
            var todo = new Todo("Task Test");

            // Assert
            todo.IsValid().Should().BeTrue();
            todo.Status.Should().HaveSameValueAs(TodoStatus.New);
        }


        [Fact]
        public void CreateNewTodo_WithDescriptionEmpty_ShouldThrowDomainException()
        {
            // Arrange & Act & Assert
            Assert.Throws<DomainException>(() => new Todo(string.Empty));
        }

        [Fact]
        public void Todo_AssingTask_ShouldBeAssignedProperly()
        {
            // Arrange
            var todo = new Todo("Task Test");
            var name = "Bill Gates";

            // Act
            todo.AssingTo(name);

            // Assert
            todo.AssignedTo.Should().Be(name);
        }

        [Fact]
        public void Todo_DoneTaks_TodoStatusShouldBeDone()
        {
            // Arrange
            var todo = new Todo("Task Test");

            // Act
            todo.DoneTask();

            // Assert
            todo.Status.Should().HaveSameValueAs(TodoStatus.Done);
        }

        [Fact]
        public void Todo_CancelTodo_TodoStatusShouldBeCanceled()
        {
            // Arrange
            var todo = new Todo("Task Test");

            // Act
            todo.CancelTodo();

            // Assert
            todo.Status.Should().HaveSameValueAs(TodoStatus.Canceled);
        }

        [Fact]
        public void Todo_DeleteTaks_TodoMustBeDeleted()
        {
            // Arrange
            var todo = new Todo("Task Test");

            // Act
            todo.DeleteTask();

            // Assert
            todo.Deleted.Should().BeTrue();
        }

        [Fact]
        public void Todo_UpdateTodo_MustHasBeenUpdatedProperly()
        {
            // Arrange
            var todo = new Todo("Task Test");
            var todoUpdate = new TodoUpdateViewModel() { Description = "New Task Name", Status = TodoStatus.OnGoing };

            // Act
            todo.Update(todoUpdate);

            // Assert
            todo.Description.Should().Be(todoUpdate.Description);
            todo.Status.Should().HaveSameValueAs(todoUpdate.Status);
        }
    }
}
