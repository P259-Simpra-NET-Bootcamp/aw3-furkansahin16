using System.Text.RegularExpressions;

namespace SimpraApi.Application;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(30).WithMessage("Product name must be less than 30 character");
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Product url cannot be empty")
            .Matches(new Regex(@"^[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$")).WithMessage("Invalid url format")
            .MaximumLength(50).WithMessage("Product url must be less than 50 character");
        RuleFor(x => x.Tag)
            .NotEmpty().WithMessage("Product tag cannot be empty")
            .MaximumLength(100).WithMessage("Product tag must be less than 100 character");
        RuleFor(x => x.CategoryId)
            .Must(id => id > 0).WithMessage("Invalid id format");
    }
}