using MediatR;

namespace Application.NoteBooks.Queries.GetNoteBookList;

public class GetNoteBookListQuery : IRequest<NoteBookListResponseModel>
{
    public Guid UserId { get; set; }
}