using FluentValidation;

namespace Application.NoteBooks.Queries.GetNoteBookList;

public class GetNoteBookListQueryValidator : AbstractValidator<GetNoteBookListQuery>
{
    public GetNoteBookListQueryValidator()
    {
        RuleFor(x => x.UserId).NotEqual(Guid.Empty);
    }
}