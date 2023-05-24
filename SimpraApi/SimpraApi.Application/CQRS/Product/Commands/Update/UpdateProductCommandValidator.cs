﻿using System.Text.RegularExpressions;

namespace SimpraApi.Application;
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty")
            .MaximumLength(30).WithMessage("Product name must be less than 30 character");
        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("Product url cannot be empty")
            .Matches(new Regex(@"^[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$")).WithMessage("Invalid url format")
            .MaximumLength(30).WithMessage("Product url must be less than 30 character");
        RuleFor(x => x.Tag)
            .NotEmpty().WithMessage("Product tag cannot be empty")
            .MaximumLength(100).WithMessage("Product tag must be less than 100 character");
        RuleFor(x => x.CategoryId)
            .Must(id => id > 0).WithMessage("Invalid id format");
        RuleFor(x => x.Id)
            .Must(id => id > 0).WithMessage("Invalid id format");
    }
}