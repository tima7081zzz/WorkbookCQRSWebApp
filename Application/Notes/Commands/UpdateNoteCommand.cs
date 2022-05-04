using MediatR;

namespace Application.Notes.Commands;

public class UpdateNoteCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}