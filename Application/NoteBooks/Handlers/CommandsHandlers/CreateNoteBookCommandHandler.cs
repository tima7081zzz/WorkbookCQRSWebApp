using Application.Interfaces;
using Application.NoteBooks.Commands;
using Domain;
using MediatR;

namespace Application.NoteBooks.Handlers;

public class CreateNoteBookCommandHandler : IRequestHandler<CreateNoteBookCommand, Guid>
{
    private readonly IWorkBookDbContext _dbContext;

    public CreateNoteBookCommandHandler(IWorkBookDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateNoteBookCommand request, CancellationToken ct)
    {
        var noteBook = new NoteBook
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            CreationDate = DateTime.Now,
            LastActivityDate = null,
            Title = request.Title,
            Description = request.Description,
        };

        await _dbContext.NoteBooks.AddAsync(noteBook, ct);
        await _dbContext.SaveChangesAsync(ct);

        return noteBook.Id;
    }
}