using FluentValidation;

namespace Application.NoteBooks.Commands.DeleteNoteBook;

public class DeleteNoteBookCommandValidator : AbstractValidator<DeleteNoteBookCommand>
{
    public DeleteNoteBookCommandValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}