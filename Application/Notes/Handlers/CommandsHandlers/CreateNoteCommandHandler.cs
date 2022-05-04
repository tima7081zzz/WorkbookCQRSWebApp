using Application.Interfaces;
using Application.Notes.Commands;
using Domain;
using MediatR;

namespace Application.Notes.Handlers;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly IWorkBookDbContext _dbContext;

    public CreateNoteCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken ct)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            NoteBookId = request.NoteBookId,
            CreationDate = DateTime.Now,
            Title = request.Title,
            Text = request.Text,
        };

        await _dbContext.Notes.AddAsync(note, ct);
        await _dbContext.SaveChangesAsync(ct);

        return note.Id;
    }
}