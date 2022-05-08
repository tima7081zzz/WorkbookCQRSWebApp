using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.NoteBooks.Commands.DeleteNoteBook;

public class DeleteNoteBookCommandHandler : IRequestHandler<DeleteNoteBookCommand>
{
    private readonly IWorkBookDbContext _dbContext;

    public DeleteNoteBookCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeleteNoteBookCommand request, CancellationToken ct)
    {
        var noteBook = await _dbContext.NoteBooks.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId, ct);

        if (noteBook == null)
        {
            throw new NotFoundException(nameof(NoteBook), request.Id);
        }

        _dbContext.NoteBooks.Remove(noteBook);

        return Unit.Value;
    }

}