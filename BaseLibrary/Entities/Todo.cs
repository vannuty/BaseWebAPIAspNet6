using BaseLibrary.Entities.Base;
using BaseLibrary.Exceptions;
using BaseLibrary.Interfaces;
using BaseLibrary.ViewModel;
using FluentValidation;
using FluentValidation.Results;

namespace BaseLibrary.Entities
{
    public class Todo : SimpleBaseEntity, IAggregateRoot
    {
        public Todo(string description, int id = 0)
        {
            if (description.Trim() == String.Empty) throw new DomainException("Description must have a value");

            Id = id;
            Description = description;
            Status = TodoStatus.New;
            CreatedAt = DateTime.Now;
            AssignedTo = "";
        }

        public string Description { get; private set; }
        public string AssignedTo { get; private set; }
        public TodoStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DoneAt { get; private set; }

        public void Update(TodoUpdateViewModel todoUpdate)
        {
            Description = todoUpdate.Description;
            Status = todoUpdate.Status;
        }

        public void AssingTo(string name)
        {
            this.AssignedTo = name;
            this.Status = TodoStatus.OnGoing;
        }

        public void CancelTodo()
        {
            this.Status = TodoStatus.Canceled;
        }

        public void DoneTask()
        {
            this.Status = TodoStatus.Done;
            this.DoneAt = DateTime.Now;
        }

        public void DeleteTask()
        {
            this.Deleted = true;
        }

        public bool IsValid()
        {
            return GetValidationResult().IsValid;
        }

        public ValidationResult GetValidationResult()
        {
            return new TodoValidation().Validate(this);
        }

        private class TodoValidation : AbstractValidator<Todo>
        {
            public TodoValidation()
            {
                RuleFor(c => c.Description)
                    .NotEqual(string.Empty)
                    .WithMessage("Description need to have a value");
            }

        }
    }

    public enum TodoStatus
    {
        New = 0,
        OnGoing = 1,
        Canceled = 2,
        Done = 3,
    }
}
