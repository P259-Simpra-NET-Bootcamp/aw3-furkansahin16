namespace SimpraApi.Application;
public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(30).WithMessage("Product name must be less than 30 character");
    }
}