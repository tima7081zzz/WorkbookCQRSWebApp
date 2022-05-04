using Application.ResponseModels;
using MediatR;

namespace Application.NoteBooks.Queries;

public class GetNoteBookDetailsQuery : IRequest<NoteBookDetailsResponseModel>
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}