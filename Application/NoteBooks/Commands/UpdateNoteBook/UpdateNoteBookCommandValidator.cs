using FluentValidation;

namespace Application.NoteBooks.Commands.UpdateNoteBook;

public class UpdateNoteBookCommandValidator : AbstractValidator<UpdateNoteBookCommand>
{
    public UpdateNoteBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}