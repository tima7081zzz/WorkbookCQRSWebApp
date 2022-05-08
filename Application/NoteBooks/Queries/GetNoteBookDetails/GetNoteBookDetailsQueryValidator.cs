using FluentValidation;

namespace Application.NoteBooks.Queries.GetNoteBookDetails;

public class GetNoteBookDetailsQueryValidator : AbstractValidator<GetNoteBookDetailsQuery>
{
    public GetNoteBookDetailsQueryValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}