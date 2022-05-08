using MediatR;

namespace Application.Notes.Queries.GetNoteList;

public class GetNoteListQuery : IRequest<NoteListResponseModel>
{
    public Guid NoteBookId { get; set; }
}