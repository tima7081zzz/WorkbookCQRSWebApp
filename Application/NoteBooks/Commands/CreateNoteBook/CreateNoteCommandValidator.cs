using FluentValidation;

namespace Application.NoteBooks.Commands.CreateNoteBook;

public class CreateNoteBookCommandValidator : AbstractValidator<CreateNoteBookCommand>
{
    public CreateNoteBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
    }
}