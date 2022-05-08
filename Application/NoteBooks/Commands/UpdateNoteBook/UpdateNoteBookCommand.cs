using MediatR;

namespace Application.NoteBooks.Commands.UpdateNoteBook;

public class UpdateNoteBookCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}