using Application.NoteBooks.ResponseModels;
using MediatR;

namespace Application.NoteBooks.Queries;

public class GetNoteDetailsQuery : IRequest<NoteDetailsResponseModel>
{
    public Guid NoteBookId { get; set; }
    public Guid Id { get; set; }
}