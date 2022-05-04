using Application.Common.Exceptions;
using Application.Interfaces;
using Application.NoteBooks.Commands;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Handlers;

public class UpdateNoteBookCommandHandler : IRequestHandler<UpdateNoteBookCommand>
{
    private readonly IWorkBookDbContext _dbContext;

    public UpdateNoteBookCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateNoteBookCommand request, CancellationToken ct)
    {
        var noteBook = await _dbContext.NoteBooks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, ct);

        if (noteBook == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }
        noteBook.Title = request.Title;
        noteBook.Description = request.Description;
        noteBook.LastActivityDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(ct);

        return Unit.Value;
    }
}