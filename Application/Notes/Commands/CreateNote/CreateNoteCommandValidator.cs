using Application.NoteBooks.Commands.CreateNoteBook;
using FluentValidation;

namespace Application.Notes.Commands.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(250);
        RuleFor(x => x.NoteBookId).NotEqual(Guid.Empty);
    }
}