using BaseLibrary.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace BaseLibrary.ViewModel
{
    public class TodoUpdateViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public TodoStatus Status { get; set; }

        public ValidationResult GetValidationResult()
        {
            return new TodoUpdateValidation().Validate(this);
        }

        private class TodoUpdateValidation : AbstractValidator<TodoUpdateViewModel>
        {
            public TodoUpdateValidation()
            {
                RuleFor(c => c.Description)
                    .NotEqual(string.Empty)
                    .WithMessage("Description need to have a value");

                RuleFor(c => c.Id)
                    .NotEqual(0)
                    .WithMessage("Bad Request");
            }

        }
    }
}
