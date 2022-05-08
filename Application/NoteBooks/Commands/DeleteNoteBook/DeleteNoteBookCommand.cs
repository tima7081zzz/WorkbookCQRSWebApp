using MediatR;

namespace Application.NoteBooks.Commands.DeleteNoteBook;

public class DeleteNoteBookCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
}