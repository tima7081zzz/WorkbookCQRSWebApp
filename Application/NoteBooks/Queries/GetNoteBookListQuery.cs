using Application.NoteBooks.ResponseModels;
using Application.ResponseModels;
using MediatR;

namespace Application.NoteBooks.Queries;

public class GetNoteBookListQuery : IRequest<NoteBookListResponseModel>
{
    public Guid UserId { get; set; }
}