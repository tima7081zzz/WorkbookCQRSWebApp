using FluentValidation;

namespace Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
{
    public GetNoteDetailsQueryValidator()
    {
        RuleFor(x => x.NoteBookId).NotEqual(Guid.Empty);
        RuleFor(x => x.Id).NotEqual(Guid.Empty);
    }
}