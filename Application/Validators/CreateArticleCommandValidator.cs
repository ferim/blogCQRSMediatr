
using Application.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;
public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        RuleFor(x => x.Article.Title).NotEmpty().MaximumLength(60);
        RuleFor(x => x.Article.Description).NotEmpty().MaximumLength(160);
        RuleFor(x => x.Article.Content).NotEmpty().MinimumLength(60);
    }

    public override ValidationResult Validate(ValidationContext<CreateArticleCommand> context)
    {
        return context.InstanceToValidate.Article is null ? new ValidationResult(new[] { new ValidationFailure("ArticleForCreationDto", "ArticleForCreationDto object is null") }) : base.Validate(context);
    }
}
