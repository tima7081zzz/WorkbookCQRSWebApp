using MediatR;

namespace Application.NoteBooks.Commands.CreateNoteBook;

public class CreateNoteBookCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}