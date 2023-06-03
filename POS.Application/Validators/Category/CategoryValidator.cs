using FluentValidation;
using POS.Application.DTOs.Request;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo {PropertyName} no puede ser nulo")
                .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío")
                .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}
