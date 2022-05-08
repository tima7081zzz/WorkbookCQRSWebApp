using MediatR;

namespace Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}