using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
{
    private readonly IWorkBookDbContext _dbContext;

    public UpdateNoteCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken ct)
    {
        var noteBook = await _dbContext.Notes.FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (noteBook == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }

        noteBook.Title = request.Title;
        noteBook.Text = request.Text;

        await _dbContext.SaveChangesAsync(ct);

        return Unit.Value;
    }
}