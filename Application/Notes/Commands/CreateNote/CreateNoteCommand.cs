using MediatR;

namespace Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid NoteBookId { get; set; }
}