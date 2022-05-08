using FluentValidation;

namespace Application.Notes.Queries.GetNoteList;

public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
{
    public GetNoteListQueryValidator()
    {
        RuleFor(x => x.NoteBookId).NotEqual(Guid.Empty);
    }
}