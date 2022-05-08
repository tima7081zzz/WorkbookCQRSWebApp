using MediatR;

namespace Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQuery : IRequest<NoteDetailsResponseModel>
{
    public Guid NoteBookId { get; set; }
    public Guid Id { get; set; }
}