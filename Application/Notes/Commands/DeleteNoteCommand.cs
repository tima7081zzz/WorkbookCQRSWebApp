using MediatR;

namespace Application.Notes.Commands;

public class DeleteNoteCommand : IRequest
{
    public Guid Id { get; set; }
}