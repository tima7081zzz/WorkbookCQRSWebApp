using Application.ResponseModels;
using MediatR;

namespace Application.NoteBooks.Queries;

public class GetNoteListQuery : IRequest<NoteListResponseModel>
{
    public Guid NoteBookId { get; set; }
}