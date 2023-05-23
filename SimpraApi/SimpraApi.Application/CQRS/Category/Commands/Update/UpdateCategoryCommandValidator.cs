namespace SimpraApi.Application;
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(30).WithMessage("Product name must be less than 30 character");
        RuleFor(x => x.Id)
            .Must(id => id > 0).WithMessage("Invalid id format");
    }
}